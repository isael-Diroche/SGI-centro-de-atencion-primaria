using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMedicamentos.Data
{
    public static class SQLiteHelper
    {

        private const string connectionString = "Data Source=C:\\Users\\Isael\\source\\repos\\GestionMedicamentos\\Data\\UserData.db;Version=3;";


        // Método para obtener una nueva conexión a la base de datos
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        public static void CreateDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Definición de la tabla Usuarios
                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Usuarios (ID INTEGER PRIMARY KEY AUTOINCREMENT, NombreUsuario TEXT NOT NULL, Contrasena TEXT NOT NULL)", connection))
                {
                    command.ExecuteNonQuery();
                }

                // Definición de la tabla Medicamentos
                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Medicamentos (IDMedicamento INTEGER PRIMARY KEY AUTOINCREMENT, NombreMedicamento TEXT NOT NULL, Dosificacion TEXT, FechaVencimiento DATE, StockDisponibilidad INTEGER)", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
