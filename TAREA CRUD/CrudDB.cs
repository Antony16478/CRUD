using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace WinFormsApp2
{
    internal class CrudDB
    {
        private readonly string _connectionString = "Server=DESKTOP-DVB2F0D\\SQLEXPRESS;Database=datos-umg;Integrated Security=True; TrustServerCertificate=True;";

        public async Task MostrarInformacionAsync()
        {
            const string query = "SELECT * FROM Tb_alumnos";
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand(query, connection);
                await connection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Console.WriteLine($"Carnet: {reader["carnet"]}, Nombre: {reader["Estudiante"]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }
        }

        public async Task AgregarAlumnoAsync(string carnet, string nombre, string email, string seccion)
        {
            const string query = "INSERT INTO Tb_Alumnos (carnet, Estudiante, email, seccion) VALUES (@carnet, @Estudiante, @email, @seccion)";
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@carnet", carnet);
                command.Parameters.AddWithValue("@Estudiante", nombre);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@seccion", seccion);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Alumno agregado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }
        }

        public async Task ActualizarAlumnoAsync(string carnet, string nombre, string email, string seccion)
        {
            const string query = "UPDATE Tb_alumnos SET Estudiante = @Estudiante, email = @email, seccion = @seccion WHERE carnet = @carnet";
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@carnet", carnet);
                command.Parameters.AddWithValue("@Estudiante", nombre);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@seccion", seccion);

                await connection.OpenAsync();
                int filas = await command.ExecuteNonQueryAsync();
                Console.WriteLine(filas > 0 ? "Alumno actualizado" : "No se encontró el alumno");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }
        }

        public async Task EliminarAlumnoAsync(string carnet)
        {
            const string query = "DELETE FROM Tb_alumnos WHERE carnet = @carnet";
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@carnet", carnet);

                await connection.OpenAsync();
                int filas = await command.ExecuteNonQueryAsync();
                Console.WriteLine(filas > 0 ? "Alumno eliminado" : "No se encontró el alumno");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }
        }

        public async Task MostrarTareasAsync(string carnet)
        {
            const string query = "SELECT * FROM tareas WHERE carnet = @carnet";
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@carnet", carnet);

                await connection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Console.WriteLine($"Carnet: {reader["carnet"]}, Nota 1: {reader["nota1"]}, Nota 2: {reader["nota2"]}, Nota 3: {reader["nota3"]}, Nota 4: {reader["nota4"]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }
        }

        public async Task AgregarTareasAsync(string carnet, int nota1, int nota2, int nota3, int nota4)
        {
            const string query = "INSERT INTO tareas (carnet, nota1, nota2, nota3, nota4) VALUES (@carnet, @nota1, @nota2, @nota3, @nota4)";
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@carnet", carnet);
                command.Parameters.AddWithValue("@nota1", nota1);
                command.Parameters.AddWithValue("@nota2", nota2);
                command.Parameters.AddWithValue("@nota3", nota3);
                command.Parameters.AddWithValue("@nota4", nota4);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Registro de notas agregado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }
        }

        public async Task ActualizarTareasAsync(string carnet, int nota1, int nota2, int nota3, int nota4)
        {
            const string query = "UPDATE tareas SET nota1 = @nota1, nota2 = @nota2, nota3 = @nota3, nota4 = @nota4 WHERE carnet = @carnet";
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@carnet", carnet);
                command.Parameters.AddWithValue("@nota1", nota1);
                command.Parameters.AddWithValue("@nota2", nota2);
                command.Parameters.AddWithValue("@nota3", nota3);
                command.Parameters.AddWithValue("@nota4", nota4);

                await connection.OpenAsync();
                int filas = await command.ExecuteNonQueryAsync();
                Console.WriteLine(filas > 0 ? "Registro de notas actualizado" : "No se encontró el registro de notas");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }
        }

        public async Task EliminarTareasAsync(string carnet)
        {
            const string query = "DELETE FROM tareas WHERE carnet = @carnet";
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@carnet", carnet);

                await connection.OpenAsync();
                int filas = await command.ExecuteNonQueryAsync();
                Console.WriteLine(filas > 0 ? "Registro de notas eliminado" : "No se encontró el registro de notas");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }
        }
    }
}