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
    public partial class FormProveedor : Form
    {
        public FormProveedor()
        {
            LoadTheme();
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormProveedoresNuevo detalle = new FormProveedoresNuevo();
            detalle.StartPosition = FormStartPosition.CenterScreen;
            detalle.ShowDialog();
            UpdateGrid();
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

        private void FormProveedor_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            LoadTheme();
        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = ProveedorBL.Instance.SelecAll();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["ProveedorId"].Value;
                string nombre = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                string Encargo = dataGridView1.CurrentRow.Cells["Encargo"].Value.ToString();
                string Telefono = dataGridView1.CurrentRow.Cells["Telefono"].Value.ToString();
                string Correo = dataGridView1.CurrentRow.Cells["Correo"].Value.ToString();
                string Direccion = dataGridView1.CurrentRow.Cells["Direccion"].Value.ToString();
                string ContactoPrincipal = dataGridView1.CurrentRow.Cells["ContactoPrincipal"].Value.ToString();
                int estadoId = (int)dataGridView1.CurrentRow.Cells["EstadoId"].Value;


                Proveedor entity = new Proveedor()
                {
                    ProveedorId = id,
                    Nombre = nombre,
                    Encargo = Encargo,
                    Telefono = Telefono,
                    Correo= Correo,
                    Direccion= Direccion,
                    ContactoPrincipal= ContactoPrincipal,
                    EstadoId = estadoId
                };

                FormProveedoresNuevo frm = new FormProveedoresNuevo(entity);
                frm.ShowDialog();

            }
            if (dataGridView1.CurrentRow.Cells["Eliminar"].Selected)
            {
                MessageBox.Show("Eliminar" + dataGridView1.CurrentRow.Cells["PagoId"].Value.ToString());
            }
            UpdateGrid();
        }
    }
}
