using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConjunto.models
{
    public class Ingredientes
    {

        private int id;
        private string nombre;
        private string imagen;

        public Ingredientes(int id, string nombre, string imagen)
        {
            this.id = id;
            this.nombre = nombre;
            this.imagen = imagen;
        }


        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Imagen { get => imagen; set => imagen = value; }
    }
}
