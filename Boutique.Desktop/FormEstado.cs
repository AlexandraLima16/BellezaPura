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
    public partial class FormEstado : Form
    {
        public FormEstado()
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormEstado_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            LoadTheme();
        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = EstadoBL.Instance.SelecAll();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormEstadoNuevo detalle = new FormEstadoNuevo();
            detalle.StartPosition = FormStartPosition.CenterScreen;
            detalle.ShowDialog();
            UpdateGrid();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["EstadoId"].Value;
                string nombre = dataGridView1.CurrentRow.Cells["NombreEstado"].Value.ToString();


                Estado entity = new Estado()
                {
                    EstadoId = id,
                    NombreEstado = nombre,
                };

                FormEstadoNuevo frm = new FormEstadoNuevo(entity);
                frm.ShowDialog();

            }
            //if (dataGridView1.CurrentRow.Cells["Eliminar"].Selected)
            //{
            //    MessageBox.Show("Eliminar" + dataGridView1.CurrentRow.Cells["EstadoId"].Value.ToString());
            //}
            UpdateGrid();
        }
    }
}
