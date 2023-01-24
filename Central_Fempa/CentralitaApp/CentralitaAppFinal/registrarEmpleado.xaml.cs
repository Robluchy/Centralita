using Newtonsoft.Json;
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

namespace CentralitaAppFinal
{
    /// <summary>
    /// Lógica de interacción para registrarEmpleado.xaml
    /// </summary>
    public partial class registrarEmpleado : Page
    {
        static HttpClient client = new HttpClient();
        public registrarEmpleado()
        {
            InitializeComponent();
        }

        private void btnrechazar_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://localhost:8080/registros";
            string contacto_persona = "3242424242"; //recoger el valor del textbox
            string email = "";
            string empresa = "empresa";
            string fecha_hora = "2020-12-12 12:12:12";
            string motivo = "llamada rechazada"; //simpre va a ser llamada pasada
            string nombre_persona = "juan";
            string observaciones = "llamada rechazada";
            string atendido_por_id = "1";
            string empleado_id = "1"; //usuario conectado


            //string json = "{\"contacto_persona\":\"" + contacto_persona + "\",\"email\":\"" + email + "\",\"empresa\":\"" + empresa + "\",\"fecha_hora\":\"" + fecha_hora + "\",\"motivo\":\"" + motivo + "\",\"nombre_persona\":\"" + nombre_persona + "\",\"observaciones\":\"" + observaciones + "\",\"atendido_por_id\":\"" + atendido_por_id + "\",\"empleado_id\":\"" + empleado_id + "\"}";
            var data = new
            {
                contacto_persona = contacto_persona,
                email = email,
                empresa = empresa,
                fecha_hora = fecha_hora,
                motivo = motivo,
                nombre_persona = nombre_persona,
                observaciones = observaciones,
                atendido_por_id = atendido_por_id,
                empleado_id = empleado_id

            };
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = client.PostAsync(url, content).Result;
            if (result.IsSuccessStatusCode)
            {
                MessageBox.Show("Registro correcto");
            }
            else
            {
                MessageBox.Show("Error al registrar");
            }

        }

    }
    }
}
