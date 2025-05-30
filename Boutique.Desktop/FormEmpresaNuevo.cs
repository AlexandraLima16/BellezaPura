using Boutique.BusinessLogic.BL;
using Boutique.DataAcces.DAL;
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
    public partial class FormEmpresaNuevo : Form
    {
        private int _id = 0;
        public FormEmpresaNuevo()
        {
            InitializeComponent();
        }
        public FormEmpresaNuevo(Empresa entity)
        {
            this.Text = "Modificar Cargo";
            _id = entity.EmpresaId;

            txtNombre.Text = entity.Nombre;
            txtTelefono.Text = entity.Telefono; 
            txtDireccion.Text = entity.Direccion;
            txtCorreo.Text = entity.Correo;
            txtNIT.Text = entity.NIT;
            txtNRC.Text = entity.NRC;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Empresa entity = new Empresa()
            {
                Nombre = txtNombre.Text.Trim(),
                Telefono= txtTelefono.Text.Trim(),
                Direccion= txtDireccion.Text.Trim(),
                Correo= txtCorreo.Text.Trim(),
                NIT= txtNIT.Text.Trim(),    
                NRC= txtNRC.Text.Trim(),    
            };

            //Nuevo
            if (_id == 0)
            {
                if (EmpresaBL.Instance.Insert(entity))
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
                entity.EmpresaId = _id;
                if (EmpresaBL.Instance.Update(entity))
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

        private void txtTipoPago_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FormEmpresaNuevo_Load(object sender, EventArgs e)
        {

        }
    }
}
