using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ProyectoConjunto.models;
using ProyectoConjunto.Models;


namespace ProyectoConjunto.viewModels
{
    public class Repositorio
    {

        public static void CargarRecetasDesdeBaseDeDatos(ObservableCollection<Receta> recetas)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT idReceta, nombre, dificultad, duracion, descripcion FROM recetas";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                int id = reader.GetInt32("idReceta");
                                string nombre = reader.GetString("nombre");
                                string dificultad = reader.GetString("dificultad");
                                string duracion = reader.GetString("duracion");
                                string descripcion = reader.GetString("descripcion");
                                int idUsuario = reader.GetInt32("idUsuario");
                                string imagen = reader.GetString("imagen");
                                
                                

                                recetas.Add(new Receta(id, nombre, dificultad, duracion, descripcion, idUsuario, imagen));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar las recetas: " + ex.Message);
            }


        }
    }
}
