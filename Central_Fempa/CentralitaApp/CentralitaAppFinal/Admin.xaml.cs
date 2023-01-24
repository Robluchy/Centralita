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
    /// Lógica de interacción para Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
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

        private void btnverRegistros_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
