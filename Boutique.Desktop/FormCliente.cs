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
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            LoadTheme();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = ClienteBL.Instance.SelecAll();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormClienteNuevo detalle = new FormClienteNuevo();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["ClienteId"].Value;
                string nombre = dataGridView1.CurrentRow.Cells["Nombres"].Value.ToString();
                string Apellidos = dataGridView1.CurrentRow.Cells["Apellidos"].Value.ToString();
                string Genero = dataGridView1.CurrentRow.Cells["Genero"].Value.ToString();
                string Telefono = dataGridView1.CurrentRow.Cells["Telefono"].Value.ToString();
                string Correo = dataGridView1.CurrentRow.Cells["Correo"].Value.ToString();
                string DUI = dataGridView1.CurrentRow.Cells["DUI"].Value.ToString();
                string Direccion = dataGridView1.CurrentRow.Cells["Direccion"].Value.ToString();


                Cliente entity = new Cliente()
                {
                    ClienteId = id,
                    Nombres = nombre,
                    Apellidos = Apellidos,
                    Genero = Genero,
                    Telefono = Telefono,
                    Correo = Correo,
                    DUI = DUI,
                    Direccion = Direccion
                };

                FormClienteNuevo frm = new FormClienteNuevo(entity);
                frm.ShowDialog();

            }
            
            UpdateGrid();
        }
    }
}
