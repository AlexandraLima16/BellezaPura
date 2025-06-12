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
        List<Producto> _ProductoList;
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
          _ProductoList = ProductoBL.Instance.SelecAll();
        }

      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var query = _ProductoList.Where(x => x.Nombre.ToLower().Contains(textBox1.Text.ToLower())
            
                                          || x.ProductoId.ToString().Contains((textBox1.Text))).ToList();

            dataGridView1.DataSource = query.ToList();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["ProductoId"].Value;
                string nombre = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                string descripcion = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                decimal precio = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Precio"].Value);
                DateTime fechaIngreso = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["FechaIngreso"].Value);
                int marcaId = (int)dataGridView1.CurrentRow.Cells["MarcaId"].Value;
                int categoriaId = (int)dataGridView1.CurrentRow.Cells["CategoriaId"].Value;
                int estadoId = (int)dataGridView1.CurrentRow.Cells["EstadoId"].Value;

                Producto entity = new Producto()
                {
                    ProductoId = id,
                    Nombre = nombre,
                    Descripcion = descripcion,
                    Precio = precio,
                    FechaIngreso = fechaIngreso,
                    MarcaId = marcaId,
                    CategoriaId = categoriaId,
                    EstadoId = estadoId
                };

                FormProductoNuevp frm = new FormProductoNuevp(entity);
                frm.ShowDialog();
            }
            if (dataGridView1.CurrentRow.Cells["Eliminar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["ProductoId"].Value;

                DialogResult dr = MessageBox.Show("Realmente desea eliminar el registro?",
                    "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (ProductoBL.Instance.Delete(id))
                    {
                        MessageBox.Show("El registro se elimino con exito",
                            "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                UpdateGrid();
            }
        }
    }
    }

