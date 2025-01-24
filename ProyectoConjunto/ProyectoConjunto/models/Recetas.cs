using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConjunto.models
{
    public class Receta
    {

        private int id;
        private string nombre;
        private string dificultad;
        private string duracion;
        private string descripcion;
        private int idUsuario;

        public Receta(int id, string nombre, string dificultad, string duracion, string descripcion, int idUsuario)
        {
            this.id = id;
            this.nombre = nombre;
            this.dificultad = dificultad;
            this.duracion = duracion;
            this.descripcion = descripcion;
            this.idUsuario = idUsuario;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Dificultad { get => dificultad; set => dificultad = value; }
        public string Duracion { get => duracion; set => duracion = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
    }
}
