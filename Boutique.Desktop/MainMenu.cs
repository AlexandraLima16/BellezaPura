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
    public partial class MainMenu : Form
    {

        private Usuario _user = null;
        private Button currenButton;
        private Random random;
        private int temIndex;
        private Form activeForm;
        public MainMenu(Usuario entity)
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
                    previousBtn.BackColor = Color.FromArgb(142,68,173);
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
            lblTitle.Text = childfrom.Text;

        }
       

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "INICIO";
            pnTitleBar.BackColor = Color.FromArgb(108, 52, 131);
            panelLogo.BackColor = Color.FromArgb(108, 52, 131);
            currenButton = null;
            btnCloseChildForm.Visible = false;
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {

        }


        private void btnCloseChildForm_Click_1(object sender, EventArgs e)
        {
            if (ActiveForm != null)
            {
                activeForm.Close();
                Reset();
            }
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
            pnCompras.Visible = false;
            pnDatosVentas.Visible = false;
            pnSistemas.Visible = false;
            pnProductos.Visible = false;
            pnDevolucion.Visible = false;
        }
        private void hideSubMenu()
        {
            if (pnDatosVentas.Visible == true)
                pnDatosVentas.Visible = false;         
            if (pnCompras.Visible == true)
                pnCompras.Visible = false;
            if (pnDevolucion.Visible == true)
                pnDevolucion.Visible = false;
            if (pnProductos.Visible == true)
                pnProductos.Visible = false; 
            if (pnSistemas.Visible == true)
                pnSistemas.Visible = false;

        }
        

        private void btnProductos_Click(object sender, EventArgs e)
        {
            showsubMenu(pnDatosVentas);
        }


        private void btnVenta_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormVentas(), sender);
            hideSubMenu();
        }

        private void btnDetalleVenta_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormDetVenta(), sender);
            hideSubMenu();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormProducto(), sender);
            hideSubMenu();
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

        private void btnCompra_Click(object sender, EventArgs e)
        {
            showsubMenu(pnCompras);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showsubMenu(pnDevolucion);
        }

        private void btnProductoslis_Click(object sender, EventArgs e)
        {
            showsubMenu(pnProductos);
        }

        private void btnSistema_Click(object sender, EventArgs e)
        {
            showsubMenu(pnSistemas);
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormCategorias(), sender);
            hideSubMenu();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDetCompra_Click(object sender, EventArgs e)
        {
            
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

        private void btnMarca_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new formMarcas(), sender);
            hideSubMenu();
        }

        private void btnRol_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormRol(), sender);
            hideSubMenu();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormUsuarioGrid(), sender);
           
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormEmpleado(), sender);  
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

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormHistorial(), sender);
            hideSubMenu();
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormEstado(), sender);
            hideSubMenu();
        }

        private void btnEstadoDev_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormEstadoDev(), sender);
            hideSubMenu();
        }

        private void pnTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDesktopPanel_Paint(object sender, PaintEventArgs e)
        {

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

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new FormDevolucion(), sender);
            hideSubMenu();
        }
    }
}
