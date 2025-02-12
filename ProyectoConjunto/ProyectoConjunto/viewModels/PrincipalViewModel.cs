using ProyectoConjunto;
using ProyectoConjunto.models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Windows;

public class PrincipalViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Receta> Recetas { get; set; }
   
    private Repositorio repositorio;
    private Receta _selectedReceta;

    public event PropertyChangedEventHandler PropertyChanged;

    public PrincipalViewModel()
    {
        Recetas = new ObservableCollection<Receta>();
        repositorio = new Repositorio();
        
        CargarRecetas();
    }

    public void CargarRecetas()
    {
        repositorio.CargarRecetasDesdeBaseDeDatos(Recetas);
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
