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
    public partial class FormReporteCompra : Form
    {
        List<ReportCompra> _ReportCompra;
        public FormReporteCompra()
        {
            InitializeComponent();
            UpdateGrid();

        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = ReporteCompraBL.Instance.SelecAll();
            _ReportCompra = ReporteCompraBL.Instance.SelecAll();
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

        private void FormReporteCompra_Load(object sender, EventArgs e)
        {
            LoadTheme();
            UpdateGrid();
            Dfecha.Format = DateTimePickerFormat.Custom;
            Dfecha.CustomFormat = "yyyy-MM-dd";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fecha = Dfecha.Value.Date;
            var lista = ReporteCompraBL.Instance.ObtenerPorFecha(fecha);

            // Muestra los resultados en el DataGridView
            dataGridView1.DataSource = lista;
            label10.Text = lista.Count.ToString();

            label8.Text = DateTime.Now.ToString("yyyy-MM-dd");
            label9.Text = lista.Count.ToString();
            decimal totalCompra = lista.Sum(x => x.TotalCompra);
            label9.Text = $"${totalCompra:F2}";
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
