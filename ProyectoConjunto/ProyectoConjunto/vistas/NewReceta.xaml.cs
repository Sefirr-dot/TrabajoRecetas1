using ProyectoConjunto.viewModels;
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

namespace ProyectoConjunto.vistas
{
    /// <summary>
    /// Lógica de interacción para NewReceta.xaml
    /// </summary>
    public partial class NewReceta : Window
    {

        private RecetaViewModel recetaViewModel;

        public NewReceta()
        {
            InitializeComponent();
            recetaViewModel = new RecetaViewModel();
            this.DataContext = recetaViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListRecetas page = new ListRecetas();
            page.Show();

            this.Close();
        }

        private void seleccionar_imagen_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is RecetaViewModel viewModel)
            {
                viewModel.SeleccionarImagen();
            }
        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            recetaViewModel.pillarDatos();
        }

        private void add_paso_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is RecetaViewModel viewModel)
            {
                viewModel.AgregarPaso();
            }
        }
    }
}
