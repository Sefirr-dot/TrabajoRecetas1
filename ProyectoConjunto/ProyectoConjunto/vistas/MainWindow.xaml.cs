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
        public MainWindow()
        {
            InitializeComponent();



            // Crear datos directamente como una lista de diccionarios
            var recetas = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "Nombre", "Tarta de Manzana" }, { "Creador", "Chef Ana" } },
                new Dictionary<string, object> { { "Nombre", "Paella Valenciana" }, { "Creador", "Chef Luis" } },
                new Dictionary<string, object> { { "Nombre", "Brownie de Chocolate" }, { "Creador", "Chef María" } },
                new Dictionary<string, object> { { "Nombre", "Pizza Margarita" }, { "Creador", "Chef José" } },
                new Dictionary<string, object> { { "Nombre", "Sopa de Tomate" }, { "Creador", "Chef Laura" } }
            };

            // Asignar directamente la lista al DataGrid
            DataGridRecetas.ItemsSource = recetas;


         


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
    }
}