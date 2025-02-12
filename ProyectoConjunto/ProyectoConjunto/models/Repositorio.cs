using MySql.Data.MySqlClient;
using ProyectoConjunto.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoConjunto.models
{
    internal class Repositorio
    {

        public ObservableCollection<Receta> CargarRecetasDesdeBaseDeDatos(ObservableCollection<Receta> recetas)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;

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
                                int duracion = Convert.ToInt32(reader["duracion"]);
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




        public ObservableCollection<Pasos> ObtenerPasosPorReceta(int idReceta)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            var pasos = new ObservableCollection<Pasos>();

            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Consulta SQL para obtener los pasos de una receta específica
                    var query = "SELECT * FROM Pasos WHERE idReceta = @idReceta ORDER BY numeroPaso";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        // Añadir el parámetro al comando
                        cmd.Parameters.AddWithValue("@idReceta", idReceta);

                        // Ejecutar la consulta y leer los datos
                        using (var reader = cmd.ExecuteReader())
                        {
                            // Leer cada registro y mapearlo a un objeto Paso
                            while (reader.Read())
                            {
                                pasos.Add(new Pasos
                                {
                                    Id = reader.GetInt32("id"),              // Leer el ID del paso
                                    NumPaso = reader.GetInt32("numPaso"), // Leer el número del paso
                                    Descripcion = reader.GetString("descripcion"), // Leer la descripción del paso
                                    IdReceta = reader.GetInt32("idReceta")    // Leer el ID de la receta
                                });
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error de base de datos: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return pasos;
        }







    }
}
