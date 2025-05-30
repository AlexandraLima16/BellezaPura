using Boutique.BusinessLogic.BL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boutique.Desktop
{
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();
            dataGridView1.BackgroundColor = Color.White;
            LoadTheme();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemColor.SecundaryColor;
                }
            }
        }

       
        private void UpdateGrid()
        {
            dataGridView1.DataSource = UsuarioBL.Instance.SelecAll();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormUsuarioNuevo detalle = new FormUsuarioNuevo();
            detalle.StartPosition = FormStartPosition.CenterScreen;
            detalle.ShowDialog();
            UpdateGrid();

        }

        

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                string dui = dataGridView1.CurrentRow.Cells["DUI"].Value.ToString();
                string nombre = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                DateTime fechaRegistro = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["FechaRegistro"].Value);
                string contraseña = dataGridView1.CurrentRow.Cells["Contrasena"].Value.ToString();
                int estadoId = (int)dataGridView1.CurrentRow.Cells["EstadoId"].Value;
                int empeladoId = (int)dataGridView1.CurrentRow.Cells["EmpleadoId"].Value;
                int rolId = (int)dataGridView1.CurrentRow.Cells["RolId"].Value;

                Usuario entity = new Usuario()
                {
                    DUI = dui,
                    Nombre = nombre,
                    FechaRegistro = fechaRegistro,
                    Contrasena = contraseña,
                    EstadoId = estadoId,
                    EmpleadoId = empeladoId,
                    RolId = rolId

                };

                FormUsuarioNuevo frm = new FormUsuarioNuevo(entity);
                frm.ShowDialog();

            }

            UpdateGrid();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {

            UpdateGrid();
            LoadTheme();
        }
    }
}
