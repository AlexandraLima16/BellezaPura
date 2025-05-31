using Boutique.BusinessLogic.BL;
using Boutique.Entity.Entidades;
using System;
using System.Windows.Forms;

namespace Boutique.Desktop
{
    public partial class MenuInicial : Form
    {
        private ErrorProvider errorProvider1 = new ErrorProvider();
        public MenuInicial()
        {
            InitializeComponent();
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink; // Opcional: para que no parpadee
            errorProvider1.ContainerControl = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDUI.Text))
            {
                errorProvider1.SetError(txtDUI, "Campo Obligatorio");
                return;
            }
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtContra.Text))
            {
                errorProvider1.SetError(txtContra, "Por favor escriba su contraeña");
                return;
            }
            errorProvider1.Clear();

            Usuario result = UsuarioBL.Instance.IniciarSesion(txtDUI.Text.Trim(), txtContra.Text.Trim());
            if (result != null)
            {
                MessageBox.Show("Bienvenido a Belleza Boutique" + result.Nombre);
                MainMenu frm = new MainMenu(result);
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error en email o en la contraseña");
            }
        }
    }
}
