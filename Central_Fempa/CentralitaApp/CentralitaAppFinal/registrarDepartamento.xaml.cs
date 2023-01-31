using CentralitaAppFinal.Clases;
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
    /// Lógica de interacción para registrarDepartamento.xaml
    /// </summary>
    public partial class registrarDepartamento : Page
    {
        static HttpClient client = new HttpClient();
        List<Departamento>departamentos = new List<Departamento>();
        string dep = "http://localhost:8080/departamento";
        public registrarDepartamento()
        {
            InitializeComponent();
        }
        private void btnRegistrarDept_Click(object sender, RoutedEventArgs e)
        {

            string departamento = txtNomDeapartamento.Text;
            JObject json = new JObject();
            json["departamento"] = departamento;

            string jsonString = json.ToString();


            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync(dep, content).Result;
            if (result.IsSuccessStatusCode)
            {
                MessageBoxResult result2 = MessageBox.Show(
                    "Registro guardado correctamente", "departamento guardado",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult result2 = MessageBox.Show(
                    "Error al guardar el departamento", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
