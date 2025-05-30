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
    public partial class FormEmpresa : Form
    {
        public FormEmpresa()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormEmpresaNuevo detalle = new FormEmpresaNuevo();
            detalle.StartPosition = FormStartPosition.CenterScreen;
            detalle.ShowDialog();
            UpdateGrid();
        }

        private void FormEmpresa_Load(object sender, EventArgs e)
        {
            LoadTheme();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = EmpresaBL.Instance.SelecAll();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["EmpresaId"].Value;
                string nombre = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                string telefono = dataGridView1.CurrentRow.Cells["Telefono"].Value.ToString();
                string Direccion = dataGridView1.CurrentRow.Cells["Direccion"].Value.ToString();
                string Correo = dataGridView1.CurrentRow.Cells["Correo"].Value.ToString();
                string NIT = dataGridView1.CurrentRow.Cells["NIT"].Value.ToString();
                string NRC = dataGridView1.CurrentRow.Cells["NRC"].Value.ToString();

                Empresa entity = new Empresa()
                {
                    EmpresaId = id,
                    Nombre = nombre,
                    Telefono = telefono,
                    Direccion = Direccion,
                    Correo = Correo,
                    NIT = NIT,
                    NRC = NRC
                };

                FormEmpresaNuevo frm = new FormEmpresaNuevo(entity);
                frm.ShowDialog();

            }

            UpdateGrid();
        }

    }
}

