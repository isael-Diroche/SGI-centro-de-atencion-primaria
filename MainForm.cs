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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Cargar los datos de la tabla Medicamentos en el DataGridView
            using (SQLiteConnection connection = SQLiteHelper.GetConnection())
            {
                connection.Open();

                string query = "SELECT IDMedicamento as ID, NombreMedicamento as Nombre, Dosificacion, FechaVencimiento as Vencimiento, StockDisponibilidad as Stock FROM Medicamentos";
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewMedicamentos.DataSource = dataTable;
                }
            }

            //AdjustDataGridViewHeight();
        }

        private void AdjustDataGridViewHeight()
        {
            Height = dataGridViewMedicamentos.ColumnHeadersHeight;

            foreach (DataGridViewRow dr in dataGridViewMedicamentos.Rows)
            {
                Height+= dr.Height;
            }

            dataGridViewMedicamentos.Height = Height;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mostrar un cuadro de diálogo para confirmar el cierre de sesión
            DialogResult result = MessageBox.Show("¿Está seguro de querer cerrar sesión?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Si el usuario confirma cerrar sesión, regresa a LoginForm
                this.Hide();

                loginForm loginForm = new loginForm();
                loginForm.ShowDialog();

                if (loginForm.DialogResult == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Mostrar un cuadro de diálogo para confirmar el cierre de sesión
            DialogResult result = MessageBox.Show("¿Está seguro de querer cerrar sesión?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Si el usuario confirma cerrar sesión, regresa a LoginForm
                this.Hide();

                loginForm loginForm = new loginForm();
                loginForm.ShowDialog();

                if (loginForm.DialogResult == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }
    }
}
