using CentralitaAppFinal.Clases;
using CentralitaAppFinal.Pages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CentralitaAppFinal
{
    /// <summary>
    /// Lógica de interacción para recogidaDeDatos.xaml
    /// </summary>
    public partial class recogidaDeDatos : Page
    {
        static HttpClient client = new HttpClient();
        List<Usuario> usuarios = Variables.ListaUsuarios;
        string registros = "http://localhost:8080/registros";
        string user = "http://localhost:8080/users";

        public recogidaDeDatos()
        {
            InitializeComponent();
            rellenarUsers();

        }
        public void rellenarUsers()
        {
            var json = new WebClient().DownloadString(user);
            var response = client.GetAsync(user).Result;
            if (response.IsSuccessStatusCode)
            {
                var usuariosJson = response.Content.ReadAsStringAsync().Result;
                // users = JsonConvert.DeserializeObject<List<Usuario>>(usuariosJson);
            }
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
            string empleado = "http://localhost:8080/users/1";
            string atendido_por = "http://localhost:8080/users/1";

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
                    mandarCorreo(telefono_persona, email, empresa, fecha_hora, motivo, nombre_persona, observaciones, atendido_por, empleado);
                }
                MessageBoxResult result2 = MessageBox.Show(
                    "Registro guardado correctamente", "Registro guardado",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult result2 = MessageBox.Show(
                    "Error al guardar el registro", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void rechazar(object sender, RoutedEventArgs e)
        {
            string motivo = "llamada rechazada";
            RegistrarLlamada(motivo);
        }

        private void atiendeRecepcion(object sender, RoutedEventArgs e)
        {
            string motivo = "atendido por recepcion";
            RegistrarLlamada(motivo);
        }

        private void envioCorreo(object sender, RoutedEventArgs e)
        {
            string motivo = "envio de correo";
            RegistrarLlamada(motivo);
        }

        private void llamadaPasada(object sender, RoutedEventArgs e)
        {
            string motivo = "llamada pasada";
            RegistrarLlamada(motivo);
        }

        private void mandarCorreo(String telefono_persona, String email, String empresa, String fecha_hora, String motivo, String nombre_persona, String observaciones, String atendido_por, String empleado)
        {
            string[] lines = File.ReadAllLines("credenciales.txt");
            string[] parts = lines[0].Split(':');
            string emailCampa = parts[0];
            string password = parts[1];
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(emailCampa);
                mail.To.Add(email);
                mail.Subject = motivo;
                mail.Body = "telefono de la persona: " + telefono_persona + "email: " + email + "empresa: " + empresa + "fecha y hora: " + fecha_hora + "motivo: " + motivo + "nombre de la persona: " + nombre_persona + "observaciones: " + observaciones + "atendido por: " + atendido_por;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential(emailCampa, password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                Console.WriteLine("Correo electrónico enviado");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

}


