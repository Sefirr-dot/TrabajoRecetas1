using ProyectoConjunto.models;
using ProyectoConjunto.singleton;
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

namespace ProyectoConjunto
{
    /// <summary>
    /// Lógica de interacción para ventanaValoracion.xaml
    /// </summary>
    public partial class ventanaValoracion : Window
    {

        private ValoracionViewModel viewModel;

        public ventanaValoracion(Receta receta)
        {
            InitializeComponent();
            viewModel = new ValoracionViewModel();
            this.DataContext = viewModel;

            viewModel.RecetaSeleccionada = receta;

            viewModel.ValoracionReceta.IdReceta = receta.Id;
            viewModel.ValoracionReceta.IdUsuario = UsuarioSingleton.id;

        }

        private void Rate_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                int rating = int.Parse(btn.Tag.ToString());
                

                // Cambia la imagen de las estrellas seleccionadas
                foreach (Button b in ((StackPanel)btn.Parent).Children)
                {
                    Image img = (Image)b.Content;
                    img.Source = new BitmapImage(new Uri(int.Parse(b.Tag.ToString()) <= rating ? "/images/estrella.png" : "/images/estrella-blanca.png", UriKind.Relative));
                }

                viewModel.ValoracionReceta.Puntuacion = rating;
            }
        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            viewModel.guardarValoracion();
            this.Close();
        }
    }

}
