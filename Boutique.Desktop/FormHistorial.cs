using Boutique.BusinessLogic.BL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boutique.Desktop
{
    public partial class FormHistorial : Form
    {
        List<Historial> _HistorialList;
        public FormHistorial()
        {
            InitializeComponent();
           

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
      

        private void FormHistorial_Load(object sender, EventArgs e)
        {
            LoadTheme();
            UpdateGrid();
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "yyyy-MM-dd";
        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = HistorialBL.Instance.SelecAll();
            _HistorialList = HistorialBL.Instance.SelecAll();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //var query = _HistorialList.Where(x => x.EventoId.Equals(int.Parse(textBox1.Text))).ToList();
            //dataGridView1.DataSource = query.ToList();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value.Date;

            // Llama a la lógica de negocio (BL) para obtener los datos
            var lista = HistorialBL.Instance.ObtenerPorFecha(fecha);

            // Muestra los resultados en el DataGridView
            dataGridView1.DataSource = lista;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
