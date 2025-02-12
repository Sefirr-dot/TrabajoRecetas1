using ProyectoConjunto.models;
using ProyectoConjunto.viewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoConjunto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private RecetaViewModel recetaViewModel;

        public MainWindow()
        {
            InitializeComponent();

            recetaViewModel = new RecetaViewModel();
            this.DataContext = new PrincipalViewModel();



        }

        

        private void PlayReceta_Click(object sender, RoutedEventArgs e)
        {
            // Abrir ventna pasos
            ventanaPasos ventanaPasos = new ventanaPasos();
            ventanaPasos.Show();
        }

        private void AñadirReceta_Click(object sender, RoutedEventArgs e)
        {
            if (this.FindName("TabControlRecetas") is TabControl tabControl)
            {
                // Cambia a la siguiente pestaña
                if (tabControl.SelectedIndex < tabControl.Items.Count - 1)
                {
                    tabControl.SelectedIndex++;
                }
                
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            recetaViewModel.pillarDatos();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (DataContext is RecetaViewModel viewModel)
            {
                viewModel.SeleccionarImagen();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DataContext is RecetaViewModel viewModel)
            {
                viewModel.AgregarPaso();
            }
        }

        private void dataGridrece_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Verificar si el ítem seleccionado es de tipo Receta
            if (dataGridrece.SelectedItem is Receta recetaSeleccionada)
            {
                // Asignar los valores de la receta a los Labels
                NombreReceta.Content = recetaSeleccionada.Nombre.ToString();
                TiempoReceta.Content = recetaSeleccionada.Duracion.ToString() + " min";
                DificultadReceta.Content = recetaSeleccionada.Dificultad;


            }
        }
    }
}