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
    public partial class FormPagos : Form
    {

        List<Pago> _PagoList;
        public FormPagos()
        {
            InitializeComponent();
        }

        private void FormPagos_Load(object sender, EventArgs e)
        {
            LoadTheme();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = PagoBL.Instance.SelecAll();
            _PagoList = PagoBL.Instance.SelecAll();
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
        private void btnNuevoPago_Click(object sender, EventArgs e)
        {
            FormNuevoPago detalle = new FormNuevoPago();
            detalle.StartPosition = FormStartPosition.CenterScreen;
            detalle.ShowDialog();
            UpdateGrid();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var query = _PagoList.Where(x => x.TipoPago.ToLower().Contains(textBox1.Text.ToLower())
                                || x.PagoId.ToString().Contains((textBox1.Text))).ToList();

            dataGridView1.DataSource = query.ToList();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            #region 
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["PagoId"].Value;
                string nombre = dataGridView1.CurrentRow.Cells["TipoPago"].Value.ToString();
                int estadoId = (int)dataGridView1.CurrentRow.Cells["EstadoId"].Value;


                Pago entity = new Pago()
                {
                    PagoId = id,
                    TipoPago = nombre,
                    EstadoId = estadoId
                };

                FormNuevoPago frm = new FormNuevoPago(entity);
                frm.ShowDialog();

            }
            if (dataGridView1.CurrentRow.Cells["Eliminar"].Selected)
            {

                int id = (int)dataGridView1.CurrentRow.Cells["PagoId"].Value;

                DialogResult dr = MessageBox.Show("Realmente desea eliminar el registro?",
                    "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (PagoBL.Instance.Delete(id))
                    {
                        MessageBox.Show("El registro se elimino con exito",
                            "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                UpdateGrid();


            }
            #endregion
        }
    }
}
