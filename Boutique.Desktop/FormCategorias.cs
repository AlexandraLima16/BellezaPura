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
    public partial class FormCategorias : Form
    {
        public FormCategorias()
        {
            InitializeComponent();
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
        private void FormCategorias_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            LoadTheme();
        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = CategoriaBL.Instance.SelecAll();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormCategoriasNuevo detalle = new FormCategoriasNuevo();
            detalle.StartPosition = FormStartPosition.CenterScreen;
            detalle.ShowDialog();
            UpdateGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["CategoriaId"].Value;
                string nombre = dataGridView1.CurrentRow.Cells["NombreCategoria"].Value.ToString();
                int estadoId = (int)dataGridView1.CurrentRow.Cells["EstadoId"].Value;


                Categoria entity = new Categoria()
                {
                    CategoriaId = id,
                    NombreCategoria = nombre,
                    EstadoId = estadoId
                };

                FormCategoriasNuevo frm = new FormCategoriasNuevo(entity);
                frm.ShowDialog();

            }
            if (dataGridView1.CurrentRow.Cells["Eliminar"].Selected)
            {
                MessageBox.Show("Eliminar" + dataGridView1.CurrentRow.Cells["PagoId"].Value.ToString());
            }
            UpdateGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
