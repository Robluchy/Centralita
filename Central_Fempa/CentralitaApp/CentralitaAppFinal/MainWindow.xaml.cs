using CentralitaAppFinal.Clases;
using CentralitaAppFinal.Pages;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        static HttpClient client = new HttpClient();
        
        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string pass = txtPassword.Password;
            
            string user = "http://localhost:8080/users/search/findByEmail?email="+txtEmail.Text;
            var result = client.GetAsync(user).Result;
            if (result.IsSuccessStatusCode)
            {
                var json = result.Content.ReadAsStringAsync().Result;
                MessageBox.Show(json);
                var userJson = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(json);
                if (userJson.password == pass)
                {
                    if (userJson.rol == true)
                    {
                        Variables.Operador = userJson;
                        MessageBox.Show("Bienvenido " + userJson.nombre_apellidos);
                        login.Visibility = Visibility.Hidden;
                        frame.Visibility = Visibility.Visible;
                        frame.NavigationService.Navigate(new Admin());
                    }
                    else
                    {
                        Variables.Operador = userJson;
                        MessageBox.Show("Bienvenido " + userJson.nombre_apellidos);
                        login.Visibility = Visibility.Hidden;
                        frame.Visibility = Visibility.Visible;
                        frame.NavigationService.Navigate(new recogidaDeDatos());
                    }
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta");
                }
            }
            else
            {
                MessageBox.Show("Usuario no encontrado");
            }
        }
    }
}
