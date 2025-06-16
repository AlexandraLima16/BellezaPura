using Boutique.BusinessLogic.BL;
using Boutique.Entity.Entidades;
using System;
using System.Collections;
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
    public partial class FormReporteVentas : Form
    {
        List<ReportVentas> _ReportVentas;
        public FormReporteVentas()
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

        private void UpdateGrid()
        {

            dataGridView1.DataSource = ReportVentaBL.Instance.SelecAll();
            _ReportVentas = ReportVentaBL.Instance.SelecAll();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fecha = Dfecha.Value.Date;

            // Llama a la lógica de negocio (BL) para obtener los datos
            var lista = ReportVentaBL.Instance.ObtenerPorFecha(fecha);

            // Muestra los resultados en el DataGridView
            dataGridView1.DataSource = lista;
          
           
        }

        private void FormReporteVentas_Load(object sender, EventArgs e)
        {
            LoadTheme();
            UpdateGrid();
            Dfecha.Format = DateTimePickerFormat.Custom;
            Dfecha.CustomFormat = "yyyy-MM-dd";

            
        }
    }
}
