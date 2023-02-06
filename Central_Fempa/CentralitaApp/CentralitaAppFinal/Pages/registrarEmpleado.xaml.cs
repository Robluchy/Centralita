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

namespace CentralitaAppFinal
{
    /// <summary>
    /// Lógica de interacción para registrarEmpleado.xaml
    /// </summary>
    public partial class registrarEmpleado : Page
    {
        static HttpClient client = new HttpClient();
        List<Usuario> users = new List<Usuario>();
        string user = "http://localhost:8080/users";

        public registrarEmpleado()
        {
            InitializeComponent();
        }
        private void btnVolver_Empleado(object sender, RoutedEventArgs e)
        {
        }

        private void btnRegistrar_Empleado(object sender, RoutedEventArgs e)
        {

            string nombre = txtNombre.Text;
            string email = txtCorreo.Text;
            string fecha_hora = DateTime.Now.ToString();
            bool rol = false;
            string pass = contrasenia.Text;
            string TELEFONO = telefono.Text;

            JObject json = new JObject();
            json["nombre"] = nombre;
            json["email"] = email;
            json["contrasenia"] = pass;
            json["fecha_hora"] = fecha_hora;
            json["TELEFONO"] = TELEFONO;


            string jsonString = json.ToString();

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync(user, content).Result;
            if (result.IsSuccessStatusCode)
            {
                //clear fields
                txtNombre.Text = "";
                txtCorreo.Text = "";
                contrasenia.Text = "";
                telefono.Text = "";
                MessageBox.Show("Empleado registrado correctamente");
            }
            else
            {
                MessageBox.Show("Error al registrar empleado");
            }
        }
    }
}
