using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConjunto.models
{
    public class Valoraciones
    {
        private int id;
        private int puntuacion;
        private string comentario;
        private int idReceta;
        private int idUsuario;

        public Valoraciones(int id, int puntuacion, string comentario, int idReceta, int idUsuario)
        {
            this.id = id;
            this.puntuacion = puntuacion;
            this.comentario = comentario;
            this.idReceta = idReceta;
            this.idUsuario = idUsuario;
        }

        public int Id { get => id; set => id = value; }
        public int Puntuacion { get => puntuacion; set => puntuacion = value; }
        public string Comentario { get => comentario; set => comentario = value; }
        public int IdReceta { get => idReceta; set => idReceta = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
    }
}
