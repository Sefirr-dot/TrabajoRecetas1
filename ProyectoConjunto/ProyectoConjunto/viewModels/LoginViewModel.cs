using ProyectoConjunto.models;
using ProyectoConjunto.repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConjunto.viewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        private Usuario usuario;

        public LoginViewModel()
        {
            usuario = new Usuario();
        }




        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal Boolean login()
        {
            Usuario u1 = new Usuario(0,Usuario.Nombre, Usuario.Password);
            return Repositorio.loginUser(u1);
        }

        public Usuario Usuario
        {
            get => usuario;
            set
            {
                usuario = value;
                OnPropertyChanged(nameof(Usuario));
            }
        }
    }
}
