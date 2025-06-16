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
    public partial class FormMenuNuevo : Form
    {
        private Usuario _user = null;
        private Button currenButton;
        private Random random;
        private int temIndex;
        private Form activeForm;
        public FormMenuNuevo(Usuario entity)
        {
            InitializeComponent();
            random = new Random();
           btnCloseChildForm.Visible = false;
            customizeDesing();
            _user = entity;
           lbNombre.Text = string.Format($"Usuario: {_user.Nombre}");
        }

        private Color SelectThemColor()
        {
            int Index = random.Next(ThemColor.ColorList.Count);
            while (temIndex == Index)
            {
                Index = random.Next(ThemColor.ColorList.Count);
            }

            temIndex = Index;
            string color = ThemColor.ColorList[Index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currenButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemColor();
                    currenButton = (Button)btnSender;
                    currenButton.BackColor = color;
                    currenButton.ForeColor = Color.White;
                    currenButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    pnTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemColor.ChangeColorBrightness(color, -0.3);
                    ThemColor.PrimaryColor = color;
                    ThemColor.SecundaryColor = ThemColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(142, 68, 173);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }
        }
        private void OpenChildFrom(Form childfrom, object sender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            ActivateButton(sender);
            activeForm = childfrom;
            childfrom.TopLevel = false;
            childfrom.FormBorderStyle = FormBorderStyle.None;
            childfrom.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childfrom);
            this.panelDesktopPanel.Tag = childfrom;
            childfrom.BringToFront();
            childfrom.Show();
            lbTitle.Text = childfrom.Text;

        }


        private void Reset()
        {
            DisableButton();
            lbTitle.Text = "INICIO";
            pnTitleBar.BackColor = Color.FromArgb(108, 52, 131);
            panelLogo.BackColor = Color.FromArgb(108, 52, 131);
            currenButton = null;
           btnCloseChildForm.Visible = false;
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {

        }


        private void horafecha_Tick(object sender, EventArgs e)
        {
            txtHora.Text = DateTime.Now.ToString("hh:mm:ss");
            txtFecha.Text = DateTime.Now.ToLongDateString();

        }
        private void showsubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void customizeDesing()
        {
            pnVenta.Visible = false;
            pnCompra.Visible = false;
            pnDevoluciones.Visible = false;
            pnProducto.Visible = false;
            pnSistema.Visible = false;
            pnReportes.Visible = false;
        }
        private void hideSubMenu()
        {
            if (pnVenta.Visible == true)
                pnVenta.Visible = false;
            if (pnCompra.Visible == true)
                pnCompra.Visible = false;
            if (pnDevoluciones.Visible == true)
                pnDevoluciones.Visible = false;
            if (pnProducto.Visible == true)
                pnProducto.Visible = false;
            if (pnSistema.Visible == true)
                pnSistema.Visible = false;
            if (pnReportes.Visible == true)
                pnReportes.Visible = false;

        }
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {

            if (ActiveForm != null)
            {
                activeForm.Close();
                Reset();
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var Confirmar = MessageBox.Show("¿Estás seguro que deseas cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Confirmar == DialogResult.Yes)
            {
                MenuInicial login = new MenuInicial();
                login.Show();
                this.Close();

            }
        }

        private void horafecha_Tick_1(object sender, EventArgs e)
        {
            txtHora.Text = DateTime.Now.ToString("hh:mm:ss");
            txtFecha.Text = DateTime.Now.ToLongDateString();
        }
        public FormMenuNuevo()
        {
            InitializeComponent();
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormUsuario(), sender);
            hideSubMenu();
        }


        private void pnTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProductoslis_Click(object sender, EventArgs e)
        {
            showsubMenu(pnProducto);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormProducto(), sender);
            hideSubMenu();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormProveedor(), sender);
            hideSubMenu();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {

            OpenChildFrom(new FormInventario(), sender);
            hideSubMenu();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {

            OpenChildFrom(new FormCategorias(), sender);
            hideSubMenu();
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new formMarcas(), sender);
            hideSubMenu();
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            showsubMenu(pnCompra);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {

        }

        private void btnDetCompra_Click(object sender, EventArgs e)
        {

        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            showsubMenu(pnVenta);
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormPagos(), sender);
            hideSubMenu();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormCliente(), sender);
            hideSubMenu();
        }

        private void btnDetalleVenta_Click(object sender, EventArgs e)
        {

            OpenChildFrom(new FormDetVenta(), sender);
            hideSubMenu();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {

            OpenChildFrom(new FormVentas(_user), sender);
            hideSubMenu();
        }

        private void btnInfoCliente_Click(object sender, EventArgs e)
        {
            showsubMenu(pnDevoluciones);
        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormDevolucion(), sender);
            hideSubMenu();
        }

        private void btnEstadoDev_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormEstadoDev(), sender);
            hideSubMenu();
        }

        private void btnSistema_Click(object sender, EventArgs e)
        {
            showsubMenu(pnSistema);
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormUsuarioGrid(), sender);
            hideSubMenu();
        }

        private void btnRol_Click(object sender, EventArgs e)
        {

            OpenChildFrom(new FormRol(), sender);
            hideSubMenu();
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormEmpleado(), sender);
            hideSubMenu();
        }

        private void btnCargo_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormCargo(), sender);
            hideSubMenu();
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormEmpresa(), sender);
            hideSubMenu();
        }

        private void btnEstado_Click_1(object sender, EventArgs e)
        {
            OpenChildFrom(new FormEstado(), sender);
            hideSubMenu();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormHistorial(), sender);
            hideSubMenu();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            showsubMenu(pnReportes);
        }

        private void btnRepStock_Click(object sender, EventArgs e)
        {

        }

        private void btnRepVentas_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void btnRepVentas_Click_1(object sender, EventArgs e)
        {
            OpenChildFrom(new FormReporteVentas(), sender);
            hideSubMenu();
        }
    }
}
