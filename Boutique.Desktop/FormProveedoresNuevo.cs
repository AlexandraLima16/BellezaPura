using Boutique.BusinessLogic.BL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Boutique.Desktop
{
    public partial class FormProveedoresNuevo : Form
    {
        private int _id = 0;
        public FormProveedoresNuevo()
        {
            InitializeComponent();
        }
        public FormProveedoresNuevo(Proveedor entity)
        {
            InitializeComponent();
            comboBoxEstado.Enabled = true;
            updateCombo();

            this.Text = "Modificar Proveedor";
            _id = entity.ProveedorId;

            txtNombre.Text = entity.Nombre;
            txtEncargo.Text = entity.Encargo;
            txtTelefono.Text = entity.Telefono;
            txtDireccion.Text = entity.Direccion;
            txtCorreo.Text = entity.Correo;
            txtContacto.Text = entity.ContactoPrincipal;
            comboBoxEstado.SelectedValue = entity.EstadoId;

        }

        private void updateCombo()
        {
            comboBoxEstado.DisplayMember = "NombreEstado";
            //Propiedad de la llave  entity 
            comboBoxEstado.ValueMember = "EstadoId";
            comboBoxEstado.DataSource = EstadoBL.Instance.SelecAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Proveedor entity = new Proveedor()
            {
                Nombre = txtNombre.Text.Trim(),
                Encargo = txtEncargo.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                ContactoPrincipal = txtContacto.Text.Trim(),
                Correo  = txtCorreo.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                EstadoId = Convert.ToString(comboBoxEstado.SelectedValue)

            };

            //Nuevo
            if (_id == 0)
            {
                if (ProveedorBL.Instance.Insert(entity))
                {
                    MessageBox.Show("Registro Agregado con exito!", "Confirmacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar el registro", "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //editar
            {
                entity.ProveedorId = _id;
                entity.EstadoId = Convert.ToString(comboBoxEstado.SelectedValue);
                if (ProveedorBL.Instance.Update(entity))
                {
                    MessageBox.Show("Registro editado con exito!", "Confirmacion",
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

        private void FormProveedoresNuevo_Load(object sender, EventArgs e)
        {
            updateCombo();
        }
    }
}
