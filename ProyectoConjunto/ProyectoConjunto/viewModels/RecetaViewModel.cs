using Microsoft.Win32;
using ProyectoConjunto.models;
using ProyectoConjunto.Models;
using System;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using ProyectoConjunto.repositorio;
using System.Collections;
using ProyectoConjunto.singleton;

namespace ProyectoConjunto.viewModels
{
    public class RecetaViewModel : INotifyPropertyChanged
    {
        private Receta recetaAGuardar;
        private Pasos pasosALista;
        private ObservableCollection<Pasos> listaPasos;
        private Repositorio repositorio;
        public ObservableCollection<Ingredientes> listIngredientes { get; set; }
        public ObservableCollection<Ingredientes> listIngredientesSeleccionados { get; set; }

        private ObservableCollection<Ingredientes> listIngredientesReceta = new ObservableCollection<Ingredientes>();

        private string nombreUser;


        
        public RecetaViewModel()
        {
            recetaAGuardar = new Receta();
            pasosALista = new Pasos();
            repositorio = new Repositorio();
            listaPasos = new ObservableCollection<Pasos>();
            listIngredientes = repositorio.CargarIngredientes();
            listIngredientesSeleccionados = new ObservableCollection<Ingredientes>();
        }

        public ObservableCollection<Ingredientes> ListIngredientesSeleccionados
        {
            get => ListIngredientesSeleccionados;
            set
            {
                ListIngredientesSeleccionados = value;
                OnPropertyChanged(nameof(listIngredientesSeleccionados));
            }
        }

        public ObservableCollection<Ingredientes> ListIngredientes
        {
            get => listIngredientes;
            set
            {
                listIngredientes = value;
                OnPropertyChanged(nameof(ListIngredientes));
            }
        }

        public string NombreUser
        {
            get => nombreUser;
            set
            {
                nombreUser = value;
                OnPropertyChanged(nameof(NombreUser));
            }
        }
        public Receta RecetaAGuardar
        {
            get => recetaAGuardar;
            set
            {
                recetaAGuardar = value;
                OnPropertyChanged(nameof(RecetaAGuardar));
            }
        }

        public Pasos PasosALista
        {
            get => pasosALista;
            set
            {
                pasosALista = value;
                OnPropertyChanged(nameof(PasosALista));
            }
        }

        public ObservableCollection<Pasos> ListaPasos
        {
            get => listaPasos;
            set
            {
                listaPasos = value;
                OnPropertyChanged(nameof(ListaPasos));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Método para seleccionar imagen desde el explorador de archivos
        public void SeleccionarImagen()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Seleccionar Imagen",
                Filter = "Archivos de imagen (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == true)
            {
                RecetaAGuardar.Imagen = openFileDialog.FileName;
                OnPropertyChanged(nameof(RecetaAGuardar));
                OnPropertyChanged(nameof(RecetaAGuardar.Imagen));
            }
        }


        public void ActualizarIngredientesSeleccionados(IList seleccionados)
        {
            listIngredientesSeleccionados.Clear();
            foreach (Ingredientes ingrediente in seleccionados)
            {
                listIngredientesSeleccionados.Add(ingrediente);
            }
            OnPropertyChanged(nameof(listIngredientesSeleccionados));
        }

        public void AniadirIngredientesReceta()
        {
            foreach (Ingredientes ingrediente in listIngredientesSeleccionados)
            {
                listIngredientesReceta.Add(ingrediente);
            }
            OnPropertyChanged(nameof(listIngredientesReceta));
        }
        // Método para mostrar la imagen en un MessageBox (opcional)
        public void pillarDatos()
        {


            if (!string.IsNullOrEmpty(RecetaAGuardar.Imagen) && File.Exists(RecetaAGuardar.Imagen))
            {
                try
                {
                    // Leer el archivo como un array de bytes
                    byte[] imageBytes = File.ReadAllBytes(RecetaAGuardar.Imagen);

                    // Convertir a Base64
                    string base64String = Convert.ToBase64String(imageBytes);

                    // Mostrar en un MessageBox (solo para pruebas)
                    MessageBox.Show(base64String);

                    // Guardar el Base64 en el objeto RecetaAGuardar
                    RecetaAGuardar.Imagen = base64String;

                    // Notificar cambios a la UI
                    OnPropertyChanged(nameof(RecetaAGuardar.Imagen));
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al convertir la imagen: {ex.Message}");
                }

                RecetaAGuardar.IdUsuario = UsuarioSingleton.id;
                AniadirIngredientesReceta();
                Repositorio.InsertarRecetaCompleta(RecetaAGuardar, ListaPasos, listIngredientesReceta);
            }
            else
            {
                MessageBox.Show("No contiene datos o la ruta de la imagen no es válida.");
            }
        }

        public void AgregarPaso()
        {
            if (PasosALista != null && !string.IsNullOrWhiteSpace(PasosALista.Descripcion))
            {
                
                ListaPasos.Add(PasosALista);

                PasosALista = new Pasos();
                OnPropertyChanged(nameof(PasosALista));
                OnPropertyChanged(nameof(ListaPasos)); 
            }
        }

        public void EliminarPasos()
        {
            ListaPasos.Clear();
            OnPropertyChanged(nameof(ListaPasos));
        }

    }
}
