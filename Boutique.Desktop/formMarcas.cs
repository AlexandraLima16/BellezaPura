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
    public partial class formMarcas : Form
    {
        List<Marca> _MarcaList;
        public formMarcas()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormMarcaNueva detalle = new FormMarcaNueva();
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

        private void formMarcas_Load(object sender, EventArgs e)
        {
            LoadTheme();
            UpdateGrid();

        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = MarcaBL.Instance.SelecAll();
            _MarcaList = MarcaBL.Instance.SelecAll();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region 
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["MarcaId"].Value;
                string nombre = dataGridView1.CurrentRow.Cells["NombreMarca"].Value.ToString();
    


                Marca entity = new Marca()
                {
                    MarcaId = id,
                    NombreMarca = nombre,
                   
                };

                FormMarcaNueva frm = new FormMarcaNueva(entity);
                frm.ShowDialog();
            }
            UpdateGrid();
            #endregion
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var query = _MarcaList.Where(x => x.NombreMarca.ToLower().Contains(textBox1.Text.ToLower())
                                || x.MarcaId.ToString().Contains((textBox1.Text))).ToList();

            dataGridView1.DataSource = query.ToList();

        }
    }
}
