using ProyectoConjunto.models;
using ProyectoConjunto.repositorio;
using ProyectoConjunto.singleton;
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
                Usuario u1 = Repositorio.cogerID(viewModel.Usuario.Nombre);
                UsuarioSingleton.setUsuario(u1.Id, u1.Nombre, u1.Password);
                ListRecetas v = new ListRecetas();
                v.Show();
                this.Close();
            } 
        }

        private void RegistraUserClick(object sender, RoutedEventArgs e)
        {
            if(viewModel.register())
            {
                Usuario u1 = Repositorio.cogerID(viewModel.Usuario.Nombre);
                UsuarioSingleton.setUsuario(u1.Id, u1.Nombre, u1.Password);
                ListRecetas v = new ListRecetas();
                v.Show();
                this.Close();
            } 
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.Usuario.Password = ((PasswordBox)sender).Password;
            }
        }

    }
}
