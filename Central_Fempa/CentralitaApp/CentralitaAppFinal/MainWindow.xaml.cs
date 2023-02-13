using CentralitaAppFinal.Clases;
using CentralitaAppFinal.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Windows;

namespace CentralitaAppFinal
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cargarLista();
        }
        string user = "http://localhost:8080/users";
        static HttpClient client = new HttpClient();
        List<Usuario> usuarios = Variables.ListaUsuarios;
        private void cargarLista()
        {
            var json = client.GetStringAsync(user).Result;
            json = JsonDocument.Parse(json).RootElement.GetProperty("_embedded").GetProperty("users").ToString();
            usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);
            var json_array = JsonDocument.Parse(json).RootElement;
            for (int i = 0; i < json_array.EnumerateArray().Count(); i++)
            {
                var json_object = json_array[i].GetProperty("_links");
                usuarios[i].id = json_object.GetProperty("self").GetProperty("href").ToString().Split("/").Last();
            }
            Variables.ListaUsuarios = usuarios;
        }

        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string pass = txtPassword.Password;
            string user = "http://localhost:8080/users/search/findByEmail?email=" + email;
            var result = client.GetAsync(user).Result;
            if (result.IsSuccessStatusCode)
            {
                var json = result.Content.ReadAsStringAsync().Result;
                var userJson = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(json);
                userJson.id = JsonObject.Parse(json)["_links"]["self"]["href"].ToString().Split("/").Last();

                if (userJson.password == pass)
                {
                    Variables.Operador = userJson;
                    if (userJson.rol == true)
                    {
                        login.Visibility = Visibility.Hidden;
                        frame.Visibility = Visibility.Visible;
                        frame.NavigationService.Navigate(new Admin());
                    }
                    else
                    {
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
