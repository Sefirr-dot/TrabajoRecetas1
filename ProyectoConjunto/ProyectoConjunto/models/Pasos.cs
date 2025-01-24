using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConjunto.models
{
    public class Pasos
    {
        private int id;
        private int numPaso;
        private string descripcion;
        private int idReceta;

        public Pasos(int id, int numPaso, string descripcion, int idReceta)
        {
            this.id = id;
            this.numPaso = numPaso;
            this.descripcion = descripcion;
            this.idReceta = idReceta;
        }

        public int Id { get => id; set => id = value; }
        public int NumPaso { get => numPaso; set => numPaso = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdReceta { get => idReceta; set => idReceta = value; }
    }
}
