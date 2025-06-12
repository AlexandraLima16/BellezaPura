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
    public partial class FormEmpleado : Form
    {
        List<Empleado> _EmpleadoList;
        public FormEmpleado()
        {
            InitializeComponent();
           
        }

        private void FormEmpleado_Load(object sender, EventArgs e)
        {
            LoadTheme();
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

        private void UpdateGrid()
        {
        
            dataGridView1.DataSource = EmpleadoBL.Instance.SelecAll();
            _EmpleadoList = EmpleadoBL.Instance.SelecAll();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormEmpleadoNuevo detalle = new FormEmpleadoNuevo();
            detalle.StartPosition = FormStartPosition.CenterScreen;
            detalle.ShowDialog();
            UpdateGrid();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var query = _EmpleadoList.Where(x => x.Nombres.ToLower().Contains(textBox1.Text.ToLower())
                                        || x.EmpleadoId.ToString().Contains((textBox1.Text))).ToList();

            dataGridView1.DataSource = query.ToList();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["EmpleadoId"].Value;
                string nombre = dataGridView1.CurrentRow.Cells["Nombres"].Value.ToString();
                string Apellidos = dataGridView1.CurrentRow.Cells["Apellidos"].Value.ToString();
                DateTime fechaNacimiento = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["FechaNacimiento"].Value);
                string DUI = dataGridView1.CurrentRow.Cells["DUI"].Value.ToString();
                string Telefono = dataGridView1.CurrentRow.Cells["Telefono"].Value.ToString();
                string Correo = dataGridView1.CurrentRow.Cells["Correo"].Value.ToString();
                string Codigo = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                string Direccion = dataGridView1.CurrentRow.Cells["Direccion"].Value.ToString();
                DateTime FechaContratacion = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["FechaContratacion"].Value);
                // FechaNacimiento = Convert.ToDateTime(dgvEmpleados.Rows[e.RowIndex].Cells["FechaNacimiento"].Value),
                int CargoId = (int)dataGridView1.CurrentRow.Cells["CargoId"].Value;
                int estadoId = (int)dataGridView1.CurrentRow.Cells["EstadoId"].Value;

                //Aqui no tiene fecha de contratacion


                Empleado entity = new Empleado()
                {
                    EmpleadoId = id,
                    Nombres = nombre,
                    Apellidos = Apellidos,
                    FechaNacimiento = fechaNacimiento,
                    DUI = DUI,
                    Telefono = Telefono,
                    Correo = Correo,
                    Codigo = Codigo,
                    Direccion = Direccion,
                    FechaContratacion = FechaContratacion,
                    CargoId = CargoId,
                    EstadoId = estadoId


                };

                FormEmpleadoNuevo frm = new FormEmpleadoNuevo(entity);
                frm.ShowDialog();
            }

            if (dataGridView1.CurrentRow.Cells["Eliminar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["EmpleadoId"].Value;

                DialogResult dr = MessageBox.Show("Realmente desea eliminar el registro?",
                    "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (EmpleadoBL.Instance.Delete(id))
                    {
                        MessageBox.Show("El registro se elimino con exito",
                            "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }





            UpdateGrid();
        }
    }
}
