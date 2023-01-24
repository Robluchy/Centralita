using CentralitaAppFinal.Clases;
using CentralitaAppFinal.fra;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private void inicio_sesion_Click(object sender, RoutedEventArgs e)
        {
            
            frame.NavigationService.Navigate(new Login());
            
        }

        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {

            login.Visibility = Visibility.Hidden;
            frame.Visibility = Visibility.Visible;

            if (txtUsuario.Text == "admin" && txtContraseña.Password == "admin")
                
            {
                frame.NavigationService.Navigate(new Admin());
            }
            else
            {
                frame.NavigationService.Navigate(new recogidaDeDatos());
            }

        }
    }
}
