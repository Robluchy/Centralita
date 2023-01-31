﻿using CentralitaAppFinal.Clases;
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
    /// Lógica de interacción para Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {

        static HttpClient client = new HttpClient();
        List<Usuario> users = new List<Usuario>();
        string registros = "http://localhost:8080/registros";
        string user = "http://localhost:8080/users";

        public Admin()
        {
            InitializeComponent();
        }

        private void btnregistrarEmpleo_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new registrarEmpleado());

        }

        private void btnregistraDepartamento_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new registrarDepartamento());
        }

        private void btnverRegistros_Click(string motivo)
        {

            string telefono_persona = txtTelefono.Text;
            string email = txtCorreo.Text;
            string empresa = txtEmpresa.Text;
            string fecha_hora = DateTime.Now.ToString();
            motivo = motivo;
            string nombre_persona = txtNombreApellidos.Text;
            string observaciones = txtObservaciones.Text;
            string atendido_por_id = "4";
            //cambiar el diseño y añadir el empleado al que se le pasa   string empleado_id = txtEmpleado.Text;

            JObject json = new JObject();
            json["telefono_persona"] = telefono_persona;
            json["email"] = email;
            json["empresa"] = empresa;
            json["fecha_hora"] = fecha_hora;
            json["motivo"] = motivo;
            json["nombre_persona"] = nombre_persona;
            json["observaciones"] = observaciones;
            json["atendido_por"] = new JObject { { "id", atendido_por_id } };
            //   json["empleado"] = new JObject { { "id", empleado_id } };

            string jsonString = json.ToString();

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync(registros, content).Result;
            if (result.IsSuccessStatusCode)
            {
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

        private void btnenvioCorreo_Click(object sender, RoutedEventArgs e)
        {
            string motivo = "envio de correo";
            btnverRegistros_Click(motivo);
            string telefono_persona = txtTelefono.Text;
            string email = txtCorreo.Text;
            string empresa = txtEmpresa.Text;
            string fecha_hora = DateTime.Now.ToString();
            motivo = motivo;
            string nombre_persona = txtNombreApellidos.Text;
            string observaciones = txtObservaciones.Text;
            string atendido_por_id = "1";
            //cambiar el diseño y añadir el empleado al que se le pasa  string empleado_id = txtEmpleado.Text;

            JObject json = new JObject();
            json["telefono_persona"] = telefono_persona;
            json["email"] = email;
            json["empresa"] = empresa;
            json["fecha_hora"] = fecha_hora;
            json["motivo"] = motivo;
            json["nombre_persona"] = nombre_persona;
            json["observaciones"] = observaciones;
            json["atendido_por"] = new JObject { { "id", atendido_por_id } };
            //    json["empleado"] = new JObject { { "id", empleado_id } };

            string jsonString = json.ToString();

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync(registros, content).Result;
            if (result.IsSuccessStatusCode)
            {
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

        private void btnrechazar_Click(object sender, RoutedEventArgs e)
        {
            string motivo = "llamada rechazada";
            btnverRegistros_Click(motivo);

            string telefono_persona = txtTelefono.Text;
            string email = txtCorreo.Text;
            string empresa = txtEmpresa.Text;
            string fecha_hora = DateTime.Now.ToString();
            motivo = motivo;
            string nombre_persona = txtNombreApellidos.Text;
            string observaciones = txtObservaciones.Text;
            string atendido_por_id = "4";
            //cambiar el diseño y añadir el empleado al que se le pasa  string empleado_id = txtEmpleado.Text;

            JObject json = new JObject();
            json["telefono_persona"] = telefono_persona;
            json["email"] = email;
            json["empresa"] = empresa;
            json["fecha_hora"] = fecha_hora;
            json["motivo"] = motivo;
            json["nombre_persona"] = nombre_persona;
            json["observaciones"] = observaciones;
            json["atendido_por"] = new JObject { { "id", atendido_por_id } };
            //      json["empleado"] = new JObject { { "id", empleado_id } };

            string jsonString = json.ToString();

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync(registros, content).Result;
            if (result.IsSuccessStatusCode)
            {
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

        private void btnatiendeRecepcion_Click(object sender, RoutedEventArgs e)
        {
            string motivo = "atendido por recepcion";
            btnverRegistros_Click(motivo);
            string telefono_persona = txtTelefono.Text;
            string email = txtCorreo.Text;
            string empresa = txtEmpresa.Text;
            string fecha_hora = DateTime.Now.ToString();
            motivo = motivo;
            string nombre_persona = txtNombreApellidos.Text;
            string observaciones = txtObservaciones.Text;
            string atendido_por_id = "1";
            //cambiar el diseño y añadir el empleado al que se le pasa  string empleado_id = txtEmpleado.Text;

            JObject json = new JObject();
            json["telefono_persona"] = telefono_persona;
            json["email"] = email;
            json["empresa"] = empresa;
            json["fecha_hora"] = fecha_hora;
            json["motivo"] = motivo;
            json["nombre_persona"] = nombre_persona;
            json["observaciones"] = observaciones;
            json["atendido_por"] = new JObject { { "id", atendido_por_id } };
            //  json["empleado"] = new JObject { { "id", empleado_id } };

            string jsonString = json.ToString();

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync(registros, content).Result;
            if (result.IsSuccessStatusCode)
            {
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

        private void btnllamadaPasada_Click(object sender, RoutedEventArgs e)
        {

            string motivo = "envio de correo";
            btnverRegistros_Click(motivo);
            string telefono_persona = txtTelefono.Text;
            string email = txtCorreo.Text;
            string empresa = txtEmpresa.Text;
            string fecha_hora = DateTime.Now.ToString();
            motivo = motivo;
            string nombre_persona = txtNombreApellidos.Text;
            string observaciones = txtObservaciones.Text;
            string atendido_por_id = "1";
            //cambiar el diseño y añadir el empleado al que se le pasa    string empleado_id = txtEmpleado.Text;

            JObject json = new JObject();
            json["telefono_persona"] = telefono_persona;
            json["email"] = email;
            json["empresa"] = empresa;
            json["fecha_hora"] = fecha_hora;
            json["motivo"] = motivo;
            json["nombre_persona"] = nombre_persona;
            json["observaciones"] = observaciones;
            json["atendido_por"] = new JObject { { "id", atendido_por_id } };
            // json["empleado"] = new JObject { { "id", empleado_id } };

            string jsonString = json.ToString();

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync(registros, content).Result;
            if (result.IsSuccessStatusCode)
            {
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

        private void btnverRegistros_Click(object sender, RoutedEventArgs e)
        {
            // que mande a una paginma donde se muestren los registros
            NavigationService.Navigate(new MostrarRegistros());
        }
    }
}