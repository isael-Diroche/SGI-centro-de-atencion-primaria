using GestionMedicamentos.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionMedicamentos
{
    public partial class loginForm : Form
    {
        private const string connectionString = "Data Source=C:\\Users\\Isael\\source\\repos\\GestionMedicamentos\\Data\\UserData.db;Version=3;";

        public loginForm()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validar el inicio de sesión con la base de datos
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @username AND Contrasena = @password", connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    int result = Convert.ToInt32(command.ExecuteScalar());

                    if (result > 0)
                    {
                        MessageBox.Show("Inicio de sesión exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        MainForm mainForm = new MainForm();
                        mainForm.ShowDialog();
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Credenciales inválidas. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            /* Validar el nombre de usuario y la contraseña (aquí se puede usar lógica de autenticación real)
            if (username == "isael" && password == "1234")
            {
                MessageBox.Show("Inicio de sesión exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Ocultar el formulario de inicio de sesión
                this.Hide();

                // Mostrar el formulario de la pantalla principal
                MainForm mainForm = new MainForm();
                mainForm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Credenciales inválidas. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar la aplicación si se hace clic en "Cancelar"
            Application.Exit();
        }
    }
}
