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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Boutique.Desktop
{
    public partial class FormUsuario : Form
    { 
        List<Usuario> _UsuarioList;
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
            _UsuarioList = UsuarioBL.Instance.SelecAll();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormUsuarioNuevo detalle = new FormUsuarioNuevo();
            detalle.StartPosition = FormStartPosition.CenterScreen;
            detalle.ShowDialog();
            UpdateGrid();

        }

        

        private void FormUsuario_Load(object sender, EventArgs e)
        {

            UpdateGrid();
            LoadTheme();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var query =_UsuarioList.Where(x=>x.Nombre.ToLower().Contains(textBox1.Text.ToLower())).ToList();
            dataGridView1.DataSource = query.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                string dui = dataGridView1.CurrentRow.Cells["DUI"].Value.ToString();
                string nombre = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                DateTime fechaRegistro = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["FechaRegistro"].Value);
                string contraseña = dataGridView1.CurrentRow.Cells["Contrasena"].Value.ToString();
                string estadoId = dataGridView1.CurrentRow.Cells["EstadoId"].Value.ToString();
                string empeladoId = dataGridView1.CurrentRow.Cells["EmpleadoId"].Value.ToString();
                string rolId = dataGridView1.CurrentRow.Cells["RolId"].Value.ToString();

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
    }
}
