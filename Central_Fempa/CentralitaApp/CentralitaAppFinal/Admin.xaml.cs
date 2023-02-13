using CentralitaAppFinal.Clases;
using CentralitaAppFinal.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace CentralitaAppFinal
{
    public partial class Admin : Page
    {
        static HttpClient client = new HttpClient();
        List<Usuario> usuarios = Variables.ListaUsuarios;
        string registros = "http://localhost:8080/registros";

        public Admin()
        {
            InitializeComponent();
            cargarComboEmpleado();
            lblUsuConectado.Content = Variables.Operador.nombre_apellido;
            
        }

        private void cargarComboEmpleado()
        {
            if (cbEmpleado != null)
            {
                cbEmpleado.Items.Clear();
                foreach (var items in usuarios)
                {
                    ComboBoxItem cbi = new ComboBoxItem();
                    cbi.Content = items.nombre_apellido;
                    cbi.Tag = items.id;
                    
                    cbEmpleado.Items.Add(cbi);
                }
            }
        }
        private void btnregistrarEmpleo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new registrarEmpleado());
        }

        private void clearFields()
        {
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtEmpresa.Text = "";
            txtNombre.Text = "";
            txtObservaciones.Text = "";
            cbEmpleado.SelectedIndex = -1;
        }

        private void RegistrarLlamada(string motivo)
        {
            string telefono_persona = txtTelefono.Text;
            string email = txtCorreo.Text;
            string empresa = txtEmpresa.Text;
            string fecha_hora = DateTime.Now.ToString();
            motivo = motivo;
            string nombre_persona = txtNombre.Text;
            string observaciones = txtObservaciones.Text;
            ComboBoxItem cbi = (ComboBoxItem)cbEmpleado.SelectedItem;
            var id_e = cbi.Tag.ToString();
            string email_e = "";
            email_e = (from u in usuarios where u.id == id_e select u.email).FirstOrDefault();
            string empleado = "http://localhost:8080/users/" + cbi.Tag.ToString();
            string atendido_por = "http://localhost:8080/users/" + Variables.Operador.id;
            string atendido_porNombre = Variables.Operador.nombre_apellido;


            var data = new
            {
                telefono_persona,
                email,
                empresa,
                fecha_hora,
                motivo,
                nombre_persona,
                observaciones,
                atendido_por,
                empleado
            };

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = client.PostAsync(registros, content).Result;
            if (result.IsSuccessStatusCode)
            {
                if (motivo == "envio de correo")
                {
                    mandarCorreo(telefono_persona, email, email_e, empresa, fecha_hora, motivo, nombre_persona, observaciones, atendido_porNombre, empleado);
                    registroTextBlock.Text = "Registro guardado correctamente";
                    registroPopup.IsOpen = true;
                    clearFields();
                }
                registroTextBlock.Text = "Registro guardado correctamente";
                registroPopup.IsOpen = true;
                clearFields();
            }
            else
            {
                registroTextBlock.Text = "Error al guardar el registro";
                registroPopup.IsOpen = true;
                clearFields();
            }
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                registroPopup.IsOpen = false;
            };
        }

        private void rechazar_admin(object sender, RoutedEventArgs e)
        {
            string motivo = "llamada rechazada";
            RegistrarLlamada(motivo);
            registroTextBlock.Text = "Llamada rechazada";
            registroPopup.IsOpen = true;
        }

        private void atiendeRecepcion_admin(object sender, RoutedEventArgs e)
        {
            string motivo = "atendido por recepcion";
            RegistrarLlamada(motivo);
            registroTextBlock.Text = "Llamada atendida por recepcion";
            registroPopup.IsOpen = true;
        }

        private void envioCorreo_admin(object sender, RoutedEventArgs e)
        {
            string motivo = "envio de correo";
            RegistrarLlamada(motivo);
            registroTextBlock.Text = "Correo enviado";
            registroPopup.IsOpen = true;
        }

        private void llamadaPasada_admin(object sender, RoutedEventArgs e)
        {
            string motivo = "llamada pasada";
            RegistrarLlamada(motivo);
            registroTextBlock.Text = "Llamada pasada";
            registroPopup.IsOpen = true;
        }
    
        private void btnverRegistros_Click(object sender, RoutedEventArgs e)
            {
                NavigationService.Navigate(new MostrarRegistros());
            }

        private void mandarCorreo(String telefono_persona, String email, String email_e, String empresa, String fecha_hora, String motivo, String nombre_persona, String observaciones, String atendido_porNombre, String empleado)
        {
            string[] lines = File.ReadAllLines("credenciales.txt");
            string[] parts = lines[0].Split(':');
            string emailCampa = parts[0];
            string password = parts[1];
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp-mail.outlook.com");

                mail.From = new MailAddress(emailCampa);
                mail.To.Add(email_e);
                mail.Subject = motivo;
                LinkedResource logo = new LinkedResource("logo_fempa.png");
                logo.ContentId = "logo";
                string htmlBody = "<html><head><style>body { font-family: Arial, sans-serif; } .header { background-color: #f2f2f2; padding: 20px; text-align: center; } .header img { width: 150px; } .content { padding: 20px; } .info { margin-bottom: 20px; } .info p { margin: 0; font-size: 14px; }</style></head><body>";
                htmlBody += "<div class='content'>";
                htmlBody += "<div class='info'><p>Telefono de la persona: " + telefono_persona + "</p><p>Email: " + email + "</p><p>Empresa: " + empresa + "</p><p>Fecha y hora: " + fecha_hora + "</p></div>";
                htmlBody += "<p><strong>Motivo:</strong> " + motivo + "</p>";
                htmlBody += "<p><strong>Señor(a) </strong> " + nombre_persona + "</p>";
                htmlBody += "<p><strong>Observaciones:</strong> " + observaciones + "</p>";
                htmlBody += "<p><strong>Atendido por:</strong> " + atendido_porNombre + "</p>";
                htmlBody += "</div><br><br></body></html>";
                //htmlBody += "<br><br><img src=cid:logo>";
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlBody + "<img src=cid:logo>", null, "text/html");
                htmlView.LinkedResources.Add(logo);
                mail.AlternateViews.Add(htmlView);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential(emailCampa, password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void txtTelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtCorreo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9@.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[^a-zA-Z ]+");
            e.Handled = regex.IsMatch(e.Text);

        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            Variables.Operador = null;
            new MainWindow().Show();
            DependencyObject parent = VisualTreeHelper.GetParent(this);
            while (!(parent is Window))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            ((Window)parent).Close();
        }

    }
}
