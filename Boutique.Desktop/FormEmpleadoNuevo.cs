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
    public partial class FormEmpleadoNuevo : Form
    {
        private int _id = 0;
        public FormEmpleadoNuevo()
        {
            InitializeComponent();
            this.Text = "Modificar Empleado";

        }
        public FormEmpleadoNuevo(Empleado entity)
        {
            InitializeComponent();
            this.Text = "Modificar Empleado";
            comboBoxcargo.Enabled = true;
            comboBoxEstado.Enabled = true;
            UpdateCombo();


            _id = entity.EmpleadoId;


            txtNombre.Text = entity.Nombres;
            txtApellido.Text = entity.Apellidos;
            txtFNacimiento.Value = entity.FechaNacimiento;
            txtDUI.Text = entity.DUI;
            txtTelefono.Text = entity.Telefono;
            txtCorreo.Text = entity.Correo;
            txtCodigo.Text = entity.Codigo;
            textDireccion.Text = entity.Direccion;
            textFechaContratacion.Value = entity.FechaContratacion;
            comboBoxcargo.SelectedValue = entity.CargoId;
            comboBoxEstado.SelectedValue = entity.EstadoId;
       
        }

        private void UpdateCombo()
        { 
           comboBoxcargo.DisplayMember = "TipoCargo";
            //Propiedad de la llave  entity 
            comboBoxcargo .ValueMember = "CargoId";
            comboBoxcargo.DataSource = CargoBL.Instance.SelecAll();
        
            comboBoxEstado.DisplayMember = "NombreEstado";
            //Propiedad de la llave  entity 
            comboBoxEstado.ValueMember = "EstadoId";
            comboBoxEstado.DataSource = EstadoBL.Instance.SelecAll();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Empleado entity = new Empleado()
            {
                Nombres = txtNombre.Text.Trim(),
                Apellidos = txtApellido.Text.Trim(),
                FechaNacimiento = txtFNacimiento.Value.Date,
                DUI = txtDUI.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Codigo = txtCodigo.Text.Trim(),
                Direccion=textDireccion.Text.Trim(),
                FechaContratacion = textFechaContratacion.Value.Date,
                CargoId = Convert.ToString(comboBoxcargo.SelectedValue),
                EstadoId = Convert.ToString(comboBoxEstado.SelectedValue)

            };

            //Nuevo
            if (_id == 0)
            {
                if (EmpleadoBL.Instance.Insert(entity))
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
                entity.EmpleadoId = _id;
                entity.EstadoId= comboBoxEstado.SelectedValue.ToString();
                entity.CargoId= comboBoxcargo.SelectedValue.ToString();
                if (EmpleadoBL.Instance.Update(entity))
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

        private void FormEmpleadoNuevo_Load(object sender, EventArgs e)
        {
            UpdateCombo();
        }

        private void txtFNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
