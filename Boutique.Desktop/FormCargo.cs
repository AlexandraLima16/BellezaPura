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
    public partial class FormCargo : Form
    {
        List<Cargo> _CargoList;
        public FormCargo()
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

        private void FormCargo_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            LoadTheme();

        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = CargoBL.Instance.SelecAll();
            _CargoList = CargoBL.Instance.SelecAll();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormCargoNuevo detalle = new FormCargoNuevo();
            detalle.StartPosition = FormStartPosition.CenterScreen;
            detalle.ShowDialog();
            UpdateGrid();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region 
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["CargoId"].Value;
                string nombre = dataGridView1.CurrentRow.Cells["TipoCargo"].Value.ToString();
                int estadoId = (int)dataGridView1.CurrentRow.Cells["EstadoId"].Value;


                Cargo entity = new Cargo()
                {
                    CargoId = id,
                    TipoCargo = nombre,
                    EstadoId = estadoId
                };

                FormCargoNuevo frm = new FormCargoNuevo(entity);
                frm.ShowDialog();

            }
            if (dataGridView1.CurrentRow.Cells["Eliminar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["CargoId"].Value;

                DialogResult dr = MessageBox.Show("Realmente desea eliminar el registro?",
                    "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (CargoBL.Instance.Delete(id))
                    {
                        MessageBox.Show("El registro se elimino con exito",
                            "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            UpdateGrid();
            #endregion

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // var query = _CargoList.Where(x => x.TipoCargo.ToLower().Contains(textBox1.Text.ToLower())
            //|| x.CargoId.Equals(int.Parse(textBox1.Text))).ToList();

            //busqueda por nombre  y ID 
            var query =_CargoList.Where(x=>x.TipoCargo.ToLower().Contains(textBox1.Text.ToLower())
                                || x.CargoId.ToString().Contains((textBox1.Text))).ToList();

            dataGridView1.DataSource = query.ToList();
        } 
      }
   }
