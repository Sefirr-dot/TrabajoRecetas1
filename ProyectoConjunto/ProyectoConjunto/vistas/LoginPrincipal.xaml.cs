using ProyectoConjunto.viewModels;
using ProyectoConjunto.vistas;
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
using System.Windows.Shapes;

namespace ProyectoConjunto
{
    /// <summary>
    /// Lógica de interacción para LoginPrincipal.xaml
    /// </summary>
    public partial class LoginPrincipal : Window
    {

        public LoginViewModel viewModel;


        public LoginPrincipal()
        {
            InitializeComponent();

            viewModel = new LoginViewModel();
            this.DataContext = viewModel;
        }

        private void IniciarSesionClick(object sender, RoutedEventArgs e)
        {


            if (viewModel.login())
            {
                ListRecetas v = new ListRecetas(viewModel.Usuario);
                v.Show();
                this.Close();
            } 
        }

        private void RegistraUserClick(object sender, RoutedEventArgs e)
        {
            if(viewModel.register())
            {
                ListRecetas v = new ListRecetas();
                v.Show();
                this.Close();
            } 
        }
    }
}
