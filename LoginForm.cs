using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionMedicamentos
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validar el nombre de usuario y la contraseña (aquí se puede usar lógica de autenticación real)
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
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar la aplicación si se hace clic en "Cancelar"
            Application.Exit();
        }
    }
}
