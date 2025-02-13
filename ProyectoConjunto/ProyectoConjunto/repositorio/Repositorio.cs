using MySql.Data.MySqlClient;
using ProyectoConjunto.models;
using ProyectoConjunto.Models;
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


        public ObservableCollection<Pasos> CargarPasosDeReceta(int idReceta)
        {
            ObservableCollection<Pasos> pasos = new ObservableCollection<Pasos>();

            string connectionString = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT id, numeroPaso, descripcion , idReceta FROM Pasos WHERE idReceta = @idReceta ORDER BY numeroPaso";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idReceta", idReceta);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Pasos paso = new Pasos
                                {
                                    Id = reader.GetInt32("id"),
                                    NumPaso = Convert.ToInt32(reader["numeroPaso"]),
                                    Descripcion = reader["descripcion"].ToString(),
                                    IdReceta = reader.GetInt32("id")
                                };

                                pasos.Add(paso);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los pasos de la receta: " + ex.Message);
            }

            return pasos;
        }

        public static Boolean loginUser(Usuario usuario)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT  nombre, password FROM usuarios WHERE nombre = @nombre AND password = @password";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@password", usuario.Password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Usuario autenticado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Usuario no autenticado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al autenticar el usuario: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return false;
        }

        public static Boolean registerUser(Usuario usuario)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Verificar si el nombre de usuario ya existe
                    string checkQuery = "SELECT COUNT(*) FROM usuarios WHERE nombre = @nombre";
                    using (var checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                        int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (userCount > 0)
                        {
                            MessageBox.Show("El nombre de usuario ya existe", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                            return false;
                        }
                    }

                    // Insertar el nuevo usuario
                    string query = "INSERT INTO usuarios (nombre, password) VALUES (@nombre, @password)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@password", usuario.Password);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Usuario registrado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Usuario no registrado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return false;
        }

    }
}
