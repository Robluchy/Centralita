﻿using CentralitaAppFinal.Clases;
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
            NavigationService.Navigate(new Uri("Admin.xaml", UriKind.Relative));
        }

        private void btnRegistrar_Empleado(object sender, RoutedEventArgs e)
        {

            string nombre = txtNombre.Text;
            string email = txtCorreo.Text;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email))
            {
                registroEmpleadoTextBlock.Text = "Nombre y correo electrónico son obligatorios";
                registroEmpleadoPopup.IsOpen = true;
                return;
            }
            var timer= new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                registroEmpleadoPopup.IsOpen = false;
            };

            
            bool rol = false;
            string pass = password.Text;
            string TELEFONO = telefono.Text;
            var data = new
            {
                nombre,
                email,
                pass,
                rol,
                TELEFONO
            };

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = client.PostAsync(user, content).Result;
            if (result.IsSuccessStatusCode)
            {
                registroEmpleadoTextBlock.Text = "Registro guardado correctamente";
                registroEmpleadoPopup.IsOpen = true;
                txtNombre.Text = "";
                txtCorreo.Text = "";
                password.Text = "";
                telefono.Text = "";
            }
            else
            {
                registroEmpleadoTextBlock.Text = "Error al guardar el registro";
                registroEmpleadoPopup.IsOpen = true;

            }
            var timer1 = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                registroEmpleadoPopup.IsOpen = false;
            };
        }
        }
    }
