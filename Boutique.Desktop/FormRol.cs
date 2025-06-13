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
    public partial class FormRol : Form
    {
        List<Rol> _RolList;
        public FormRol()
        {
            InitializeComponent();
           
        }

        private void FormRol_Load(object sender, EventArgs e)
        {
            UpdateGrid();
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
        private void UpdateGrid()
        {
            dataGridView1.DataSource = RolBL.Instance.SelecAll();
            _RolList = RolBL.Instance.SelecAll();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormRolNuevo detalle = new FormRolNuevo();
            detalle.StartPosition = FormStartPosition.CenterScreen;
            detalle.ShowDialog();
            UpdateGrid();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var query = _RolList.Where(x => x.NombreRol.ToLower().Contains(textBox1.Text.ToLower())
                                || x.RolId.ToString().Contains((textBox1.Text))).ToList();

            dataGridView1.DataSource = query.ToList();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            #region 
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["RolId"].Value;
                string nombre = dataGridView1.CurrentRow.Cells["NombreRol"].Value.ToString();
                string estadoId = dataGridView1.CurrentRow.Cells["EstadoId"].Value.ToString();


                Rol entity = new Rol()
                {
                    RolId = id,
                    NombreRol = nombre,
                    EstadoId = estadoId
                };

                FormRolNuevo frm = new FormRolNuevo(entity);
                frm.ShowDialog();

            }
            if (dataGridView1.CurrentRow.Cells["Eliminar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["RolId"].Value;

                DialogResult dr = MessageBox.Show("Realmente desea eliminar el registro?",
                    "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (RolBL.Instance.Delete(id))
                    {
                        MessageBox.Show("El registro se elimino con exito",
                            "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            UpdateGrid();
            #endregion
        }
    }
}
