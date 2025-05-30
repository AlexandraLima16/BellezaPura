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
    public partial class FormProducto : Form
    {
        public FormProducto()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormProductoNuevp detalle = new FormProductoNuevp();
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

        private void FormProducto_Load(object sender, EventArgs e)
        {
            LoadTheme();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = ProductoBL.Instance.SelecAll();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["ProductoId"].Value;
                string nombre = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                string descripcion = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                DateTime fechaIngreso = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["FechaIngreso"].Value);
                decimal precio = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Precio"].Value);
                int marcaId = (int)dataGridView1.CurrentRow.Cells["MarcaId"].Value;
                int categoriaId = (int)dataGridView1.CurrentRow.Cells["CategoriaId"].Value;
                int estadoId = (int)dataGridView1.CurrentRow.Cells["EstadoId"].Value;

                Producto entity = new Producto()
                {
                    ProductoId = id,
                    Nombre = nombre,
                    Descripcion = descripcion,
                    FechaIngreso = fechaIngreso,  
                    Precio = precio,
                    MarcaId = marcaId,
                    CategoriaId=categoriaId,
                    EstadoId=estadoId
                };

                FormProductoNuevp frm = new FormProductoNuevp(entity);
            }
            if (dataGridView1.CurrentRow.Cells["Eliminar"].Selected)
            {
                MessageBox.Show("Eliminar" + dataGridView1.CurrentRow.Cells["ProductoId"].Value.ToString());
            }
        }
    }
}
