﻿using MySql.Data.MySqlClient;
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
using System.Windows.Controls;

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

                                int id = Convert.ToInt32(reader["id"]);
                                string nombre = reader["nombre"].ToString();
                                string dificultad = reader["dificultad"].ToString();
                                string duracion = Convert.ToString(reader["duracion"]);
                                string descripcion = reader["descripcion"].ToString();
                                int idUsuario = Convert.ToInt32(reader["idUsuario"]);
                                string imagen = reader["imagen"].ToString();

                                // Obtener la media de las valoraciones para esta receta
                                double mediaValoraciones = ObtenerMediaValoracionesPorReceta(id);

                                // Crear el objeto Receta con la media
                                Receta receta = new Receta(id, nombre, dificultad, duracion, descripcion, idUsuario, imagen, mediaValoraciones);


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

        public static ObservableCollection<Ingredientes> CargarIngredientesReceta(Receta rec)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;

            ObservableCollection<Ingredientes> ing = new ObservableCollection<Ingredientes>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();


                    string query = "SELECT i.id, i.nombre, i.imagen FROM Ingredientes i INNER JOIN IngredientesRecetas ir ON i.id = ir.idIngrediente WHERE idReceta = " + rec.Id;

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                int id = Convert.ToInt32(reader["id"]);
                                string nombre = reader["nombre"].ToString();
                                string imagen = reader["imagen"].ToString();

                                // Crear el objeto Receta con la media
                                Ingredientes ingre = new Ingredientes(id, nombre, imagen);


                                ing.Add(ingre);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las recetas: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return ing;
        }

        public static ObservableCollection<Pasos> CargarPasosReceta(Receta rec)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;

            ObservableCollection<Pasos> pas = new ObservableCollection<Pasos>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();


                    string query = "SELECT id, numeroPaso, descripcion FROM pasos WHERE idReceta = " + rec.Id;

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                int id = Convert.ToInt32(reader["id"]);
                                int numPaso = Convert.ToInt32(reader["numeroPaso"]);
                                string descripcion = reader["descripcion"].ToString();

                                // Crear el objeto Receta con la media
                                Pasos pa = new Pasos(id, numPaso, descripcion, rec.Id);


                                pas.Add(pa);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las recetas: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return pas;
        }

        // Método para obtener la media de las valoraciones de una receta
        public double ObtenerMediaValoracionesPorReceta(int idReceta)
        {
            double media = 0.0;
            string connectionString = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT AVG(puntuacion) AS MediaValoraciones FROM valoraciones WHERE idReceta = @idReceta";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idReceta", idReceta);

                        // Ejecutar la consulta y obtener el resultado de la media
                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            media = Convert.ToDouble(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la media de las valoraciones: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return media;
        }


        public ObservableCollection<Ingredientes> CargarIngredientes()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;

            ObservableCollection<Ingredientes> ingredientes = new ObservableCollection<Ingredientes>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT id, nombre, imagen FROM ingredientes";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Crear una nueva receta y asignar los valores
                                int id = Convert.ToInt32(reader["id"]);
                                string nombre = reader["nombre"].ToString();
                                string imagen = reader["imagen"].ToString();

                                // Crear el objeto Receta
                                Ingredientes ing = new Ingredientes(id, nombre, imagen);

                                // Añadir la receta a la lista
                                ingredientes.Add(ing);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las recetas: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return ingredientes;
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

                    string query = "SELECT nombre, password FROM usuarios WHERE nombre = @nombre";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string password = reader.GetString("password");

                                if(BCrypt.Net.BCrypt.Verify(usuario.Password, password))
                                {
                                    MessageBox.Show("Usuario autenticado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                                    return true;

                                } else
                                {
                                    MessageBox.Show("Usuario no autenticado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                                    return false;
                                }

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
                        cmd.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.HashPassword(usuario.Password));
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

        public static Usuario cogerID(string user)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT id,nombre,password FROM usuarios WHERE nombre=@nombre";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", user);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                int id = Convert.ToInt32(reader["id"]);
                                string nombre = reader["nombre"].ToString();
                                string password = reader["password"].ToString();
                                return new Usuario(id, nombre, password);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las recetas: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return new Usuario();
        }

        public static void guardarValoracion(Valoraciones valoracion)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO valoraciones (puntuacion, comentario, idREceta, idUsuario) VALUES (@puntuacion, @comentario, @idREceta, @idUsuario)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@puntuacion", valoracion.Puntuacion);
                        cmd.Parameters.AddWithValue("@comentario", valoracion.Comentario);
                        cmd.Parameters.AddWithValue("@idReceta", valoracion.IdReceta);
                        cmd.Parameters.AddWithValue("@idUsuario", valoracion.IdUsuario);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Valoracion Guardada", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Valoración no guardada", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la valoracion: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public static int InsertarRecetaCompleta(Receta receta, ObservableCollection<Pasos> listaPasos, ObservableCollection<Ingredientes> ingredientes)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar la receta principal
                        string queryReceta = @"INSERT INTO Recetas (nombre, dificultad, duracion, descripcion, idUsuario, imagen) 
                                     VALUES (@nombre, @dificultad, @duracion, @descripcion, @idUsuario, @imagen);
                                     SELECT LAST_INSERT_ID();";

                        int idReceta;
                        using (var cmd = new MySqlCommand(queryReceta, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@nombre", receta.Nombre);
                            cmd.Parameters.AddWithValue("@dificultad", receta.Dificultad);
                            cmd.Parameters.AddWithValue("@duracion", receta.Duracion);
                            cmd.Parameters.AddWithValue("@descripcion", receta.Descripcion);
                            cmd.Parameters.AddWithValue("@idUsuario", receta.IdUsuario);
                            cmd.Parameters.AddWithValue("@imagen", receta.Imagen);

                            idReceta = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 2. Insertar los pasos
                        string queryPasos = @"INSERT INTO Pasos (numeroPaso, descripcion, idReceta) 
                                    VALUES (@numeroPaso, @descripcion, @idReceta)";

                        foreach (var paso in listaPasos)
                        {
                            using (var cmd = new MySqlCommand(queryPasos, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@numeroPaso", paso.NumPaso);
                                cmd.Parameters.AddWithValue("@descripcion", paso.Descripcion);
                                cmd.Parameters.AddWithValue("@idReceta", idReceta);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 3. Insertar los ingredientes
                        string queryIngredientes = @"INSERT INTO ingredientesrecetas (idIngrediente, idReceta) 
                                           VALUES (@idIngrediente, @idReceta)";

                        foreach (var ingrediente in ingredientes)
                        {
                            using (var cmd = new MySqlCommand(queryIngredientes, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@idIngrediente", ingrediente.Id);
                                cmd.Parameters.AddWithValue("@idReceta", idReceta);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Receta guardada exitosamente");
                        return idReceta;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al insertar la receta: " + ex.Message);
                    }
                }
            }

        }
        public static void EliminarReceta(Receta r1)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM recetas WHERE id = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", r1.Id);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Receta eliminada", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Receta no eliminada", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la receta: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
