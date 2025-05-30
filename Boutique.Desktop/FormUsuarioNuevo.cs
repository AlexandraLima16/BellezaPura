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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Boutique.Desktop
{
    public partial class FormUsuarioNuevo : Form
    {

        public FormUsuarioNuevo()
        {
            InitializeComponent();
            this.Text = "Editar Usuario";
            
        }
        public FormUsuarioNuevo(Usuario entity)
        {
            InitializeComponent();

            this.Text = "Editar Usuario";
            cbEstado.Enabled = true;
            cbEmpleado.Enabled = true;
            cbRol.Enabled = true;
            UpdateCombo();

            txtDui.Text = entity.DUI;
            txtName.Text=entity.Nombre;
            dtpFecha.Value = entity.FechaRegistro;
            txtContraseña.Text = entity.Contrasena;
            cbEstado.SelectedValue = entity.EstadoId;
            cbEmpleado.SelectedValue = entity.EmpleadoId;
            cbRol.SelectedValue = entity.RolId;


        }

        private void UpdateCombo()
        {
            cbEstado.DisplayMember = "NombreEstado";
            cbEstado.ValueMember = "EstadoId";
            cbEstado.DataSource = EstadoBL.Instance.SelecAll();

            cbEmpleado.DisplayMember = "Nombres";
            cbEmpleado.ValueMember = "EmpleadoId";
            cbEmpleado.DataSource = EmpleadoBL.Instance.SelecAll();

            cbRol.DisplayMember = "NombreRol";
            cbRol.ValueMember = "RolId";
            cbRol.DataSource = RolBL.Instance.SelecAll();
        }

        private void FormUsuarioNuevo_Load(object sender, EventArgs e)
        {
            UpdateCombo();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario entity = new Usuario()
            {
                DUI = txtDui.Text.Trim(),
                Nombre = txtName.Text.Trim(),
                FechaRegistro= DateTime.Parse(dtpFecha.Text.Trim()),
                Contrasena = txtContraseña.Text.Trim(),
                EstadoId = (int)cbEstado.SelectedValue,
                EmpleadoId = (int)cbEmpleado.SelectedValue,
                RolId = (int)cbRol.SelectedValue


            };


            if (UsuarioBL.Instance.Existe(entity.DUI))
            {
                // Editar
                if (UsuarioBL.Instance.Update(entity))
                {
                    MessageBox.Show("Registro editado con éxito!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al editar el registro", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Insertar
                if (UsuarioBL.Instance.Insert(entity))
                {
                    MessageBox.Show("Registro agregado con éxito!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar el registro", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.Close();
        }
    }
}
