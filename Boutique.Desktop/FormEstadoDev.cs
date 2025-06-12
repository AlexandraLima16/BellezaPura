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
    public partial class FormEstadoDev : Form
    {
        public FormEstadoDev()
        {
            InitializeComponent();
        }

        private void FormEstadoDev_Load(object sender, EventArgs e)
        {
            LoadTheme();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = EstadoDevBL.Instance.SelecAll();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormNuevoEstadoDev detalle = new FormNuevoEstadoDev();
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

     

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["EstadoDevId"].Value;
                string nombre = dataGridView1.CurrentRow.Cells["NombreEstadoDev"].Value.ToString();



                EstadoDev entity = new EstadoDev()
                {
                    EstadoDevId = id,
                    NombreEstadoDev = nombre
                };

                FormNuevoEstadoDev frm = new FormNuevoEstadoDev(entity);
                frm.ShowDialog();

            }
        }
    }
}
