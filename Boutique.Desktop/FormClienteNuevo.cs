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
    public partial class FormClienteNuevo : Form
    {
        private int _id = 0;
        public FormClienteNuevo()
        {
            InitializeComponent();
        }
        public FormClienteNuevo(Cliente entity)
        {
            InitializeComponent();
            this.Text = "Modificar Categoria";
            _id = entity.ClienteId;

            txtNombre.Text = entity.Nombres;
            txtApellido.Text = entity.Apellidos;
            txtGenero.Text = entity.Genero;
            txtTelefono.Text = entity.Telefono;
            txtCorreo.Text = entity.Correo;
            txtDUI.Text = entity.DUI;
            txtDireccion.Text = entity.Direccion;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente entity = new Cliente()
            {
                Nombres  = txtNombre.Text.Trim(),
                Apellidos = txtApellido.Text.Trim(),
                Genero = txtGenero.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                DUI = txtDUI.Text.Trim(),
                Direccion = txtDireccion.Text.Trim()

            };

            //Nuevo
            if (_id == 0)
            {
                if (ClienteBL.Instance.Insert(entity))
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
                entity.ClienteId = _id;
                if (ClienteBL.Instance.Update(entity))
                {
                    MessageBox.Show("Registro ediado con exito!", "Confirmacion",
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

        private void FormClienteNuevo_Load(object sender, EventArgs e)
        {
        }
    }
}
