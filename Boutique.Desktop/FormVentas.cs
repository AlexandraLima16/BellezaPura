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
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
            
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
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormNuevaVenta detalle = new FormNuevaVenta();
            detalle.StartPosition = FormStartPosition.CenterScreen;
            detalle.ShowDialog();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
