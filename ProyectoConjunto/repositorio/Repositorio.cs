using MySql.Data.MySqlClient;
using ProyectoConjunto.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoConjunto.repositorio
{
    public class Repositorio
    {

        public ObservableCollection<Receta> CargarRecetasDesdeBaseDeDatos()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;

            ObservableCollection<Receta> recetas = new ObservableCollection<Receta>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT id, nombre, dificultad, duracion, descripcion, idUsuario, imagen FROM recetas";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Crear una nueva receta y asignar los valores
                                int id = Convert.ToInt32(reader["id"]);
                                string nombre = reader["nombre"].ToString();
                                string dificultad = reader["dificultad"].ToString();
                                string duracion = Convert.ToString(reader["duracion"]);
                                string descripcion = reader["descripcion"].ToString();
                                int idUsuario = Convert.ToInt32(reader["idUsuario"]);
                                string imagen = reader["imagen"].ToString();

                                // Crear el objeto Receta
                                Receta receta = new Receta(id, nombre, dificultad, duracion, descripcion, idUsuario, imagen);

                                // Añadir la receta a la lista
                                recetas.Add(receta);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las recetas: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return recetas;
        }

    }
}
