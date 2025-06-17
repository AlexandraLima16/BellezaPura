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
    public partial class FormRolNuevo : Form
    {
        private int _id = 0;
        public FormRolNuevo()
        {
            InitializeComponent();
        }
        public FormRolNuevo(Rol entity)
        {
            InitializeComponent();
            comboBoxEstado.Enabled = true;
            updateCombo();

            this.Text = "Modificar Cargo";
            _id = entity.RolId;

            txtNombreRol.Text = entity.NombreRol;
            comboBoxEstado.SelectedValue = entity.EstadoId;
        }

        private void updateCombo()
        {
            //Popiedad a mostrar la entity 

            comboBoxEstado.DisplayMember = "NombreEstado";
            //Propiedad de la llave  entity 
            comboBoxEstado.ValueMember = "EstadoId";
            comboBoxEstado.DataSource = EstadoBL.Instance.SelecAll();
        }

        private void FormRolNuevo_Load(object sender, EventArgs e)
        {
            updateCombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rol entity = new Rol()
            {
                NombreRol = txtNombreRol.Text.Trim(),
                EstadoId = Convert.ToString(comboBoxEstado.SelectedValue)
          

            };

            //Nuevo
            if (_id == 0)
            {
                if (RolBL.Instance.Insert(entity))
                {
                    MessageBox.Show("Registro Agregado con edito!", "Confirmacion",
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
                entity.RolId = _id;
                entity.EstadoId = Convert.ToString(comboBoxEstado.SelectedValue);
                if (RolBL.Instance.Update(entity))
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

    }
}
