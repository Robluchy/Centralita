using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
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
using CentralitaAppFinal.Clases;

namespace CentralitaAppFinal
{
    /// <summary>
    /// Lógica de interacción para registrarDepartamento.xaml
    /// </summary>
    public partial class registrarDepartamento : Page
    {
        static HttpClient client = new HttpClient();
        List<Usuario> users = new List<Usuario>();
        string user = "http://localhost:8080/users";
        public registrarDepartamento()
        {
            InitializeComponent();
        }
        private void btnRegistrarDepa(object sender, RoutedEventArgs e)
        {

            string nombre = txtNombre.Text;
            string email = txtCorreo.Text;
            string fecha_hora = DateTime.Now.ToString();
            bool rol = false;
            string TELEFONO = telefono.Text;

            JObject json = new JObject();
            json["nombre"] = nombre;
            json["email"] = email;
            json["fecha_hora"] = fecha_hora;
            json["TELEFONO"] = TELEFONO;

            string jsonString = json.ToString();

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync(user, content).Result;
            if (result.IsSuccessStatusCode)
            {
                MessageBoxResult result2 = MessageBox.Show(
                    "Registro guardado correctamente", "usuario guardado",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult result2 = MessageBox.Show(
                    "Error al guardar el usuario", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnVolver_Clic(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));

        }
    }
}
