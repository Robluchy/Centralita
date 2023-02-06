using CentralitaAppFinal.Clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
using System.Windows.Threading;

namespace CentralitaAppFinal
{
    /// <summary>
    /// Lógica de interacción para recogidaDeDatos.xaml
    /// </summary>
    public partial class recogidaDeDatos : Page
    {
        static HttpClient client = new HttpClient();
        List<Usuario> users = new List<Usuario>();
        string registros = "http://localhost:8080/registros";
        string user = "http://localhost:8080/users";

        public recogidaDeDatos()
        {
            InitializeComponent();
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
            string atendido_por_id = "1";
            string empleado_id = txtEmpleado.Text;

            JObject json = new JObject();
            json["telefono_persona"] = telefono_persona;
            json["email"] = email;
            json["empresa"] = empresa;
            json["fecha_hora"] = fecha_hora;
            json["motivo"] = motivo;
            json["nombre_persona"] = nombre_persona;
            json["observaciones"] = observaciones;
            json["atendido_por"] = new JObject { { "id", atendido_por_id } };
            json["empleado"] = new JObject { { "id", empleado_id } };

            string jsonString = json.ToString();

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync(registros, content).Result;
            if (result.IsSuccessStatusCode)
            {
                registroRecogidaTextBlock.Text = "Registro guardado correctamente";
                registroRecogidaPopup.IsOpen = true;
                //clear fields
                txtNombre.Text = "";
                txtCorreo.Text = "";
                txtTelefono.Text = "";
                txtEmpresa.Text = "";
                txtObservaciones.Text = "";
                txtEmpleado.Text = "";
                

            }
            else
            {
                registroRecogidaTextBlock.Text = "Error al guardar el registro";
                registroRecogidaPopup.IsOpen = true;
            }
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                registroRecogidaPopup.IsOpen = false;
            };
        }
        
        private void rechazar(object sender, RoutedEventArgs e)
        {
            string motivo = "llamada rechazada";
            RegistrarLlamada(motivo);
            registroRecogidaTextBlock.Text = "Llamada rechazada";
            registroRecogidaPopup.IsOpen = true;
        }

        private void atiendeRecepcion(object sender, RoutedEventArgs e)
        {
            string motivo = "atendido por recepcion";
            RegistrarLlamada(motivo);
            registroRecogidaTextBlock.Text = "Llamada atendida por recepcion";
            registroRecogidaPopup.IsOpen = true;
        }

        private void envioCorreo(object sender, RoutedEventArgs e)
        {
            string motivo = "envio de correo";
            RegistrarLlamada(motivo);
            registroRecogidaTextBlock.Text = "Correo enviado";
            registroRecogidaPopup.IsOpen = true;
        }

        private void llamadaPasada(object sender, RoutedEventArgs e)
        {
            string motivo = "llamada pasada";
            RegistrarLlamada(motivo);
            registroRecogidaTextBlock.Text = "Llamada pasada";
            registroRecogidaPopup.IsOpen = true;
        }

    }
}

