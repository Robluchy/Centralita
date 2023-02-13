using CentralitaAppFinal.Clases;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para MostrarRegistros.xaml
    /// </summary>
    public partial class MostrarRegistros : Page
    {
        List<Registros> registros = new List<Registros>();
        public MostrarRegistros()
        {
            InitializeComponent();
            getRegistros();
        }
        static HttpClient client = new HttpClient();

        private void getRegistros()
        {
            string url = "http://localhost:8080/registros";
            var result = client.GetAsync(url).Result;
            var json = result.Content.ReadAsStringAsync().Result;
            var obj = JObject.Parse(json)["_embedded"]["registros"];

            JArray array = JArray.Parse(obj.ToString());

            foreach (JObject o in array.Children<JObject>())
            {
                List<string> propList = new List<string>();
                foreach (JProperty singleProp in o.Properties())
                {
                    if (singleProp.Name != "_links")
                    {
                        propList.Add(singleProp.Value.ToString());
                    }
                }
                Registros r = new Registros(propList[0], propList[1], propList[2], propList[3], propList[4], propList[5], propList[6]);
                registros.Add(r);
                grid.Items.Add(new { r.email, r.empresa, r.fecha_hora, r.motivo, r.nombre_persona, r.observaciones, r.telefono_persona });
            }
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            var filename = "asdasdsa.csv";

            using (var writer = new System.IO.StreamWriter(filename))
            {
                writer.WriteLine("email,empresa,fecha_hora,motivo,nombre_persona,observaciones,telefono_persona");
                foreach (var llamada in registros)
                {
                    writer.WriteLine($"{llamada.email},{llamada.empresa},{llamada.fecha_hora},{llamada.motivo},{llamada.nombre_persona},{llamada.observaciones},{llamada.telefono_persona}");
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = filename;
            saveFileDialog.Filter = "CSV file (.csv)|.csv";

            if (saveFileDialog.ShowDialog() == true)
            {
                File.Copy(filename, saveFileDialog.FileName, true);
            }
        }
        
    }
}
