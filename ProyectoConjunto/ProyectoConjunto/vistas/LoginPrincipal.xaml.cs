﻿using System;
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
        public LoginPrincipal()
        {
            InitializeComponent();
        }

        private void IniciarSesionClick(object sender, RoutedEventArgs e)
        {
            // Abrir ventna pasos
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
