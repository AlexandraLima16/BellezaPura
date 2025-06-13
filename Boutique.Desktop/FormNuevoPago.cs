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

namespace Boutique.Desktop
{
    public partial class FormNuevoPago : Form
    {
        private int _id = 0;
        public FormNuevoPago()
        {
            InitializeComponent();
        }

        public FormNuevoPago(Pago entity)
        {
            InitializeComponent();
            comboBox1.Enabled = true;
            updateCombo();


            this.Text = "Modificar Pago";
            _id = entity.PagoId;

            textBox1.Text = entity.TipoPago;

            comboBox1.SelectedValue = entity.EstadoId;
        }

        private void updateCombo()
        {
            //Popiedad a mostrar la entity 

            comboBox1.DisplayMember = "NombreEstado";
            //Propiedad de la llave  entity 
            comboBox1.ValueMember = "EstadoId";
            comboBox1.DataSource = EstadoBL.Instance.SelecAll();

        }

        private void FormNuevoPago_Load(object sender, EventArgs e)
        {
            updateCombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text == "")
            //{
            //    ErrorProvider.Equals(textBox1, "Campo obligatorio");
            //    return;
            //}
            //ErrorProvider.();

            Pago entity = new Pago()
            {
                TipoPago = textBox1.Text.Trim(),
                EstadoId = Convert.ToString(comboBox1.SelectedValue)
            };
       

            //Nuevo
            if (_id == 0)
            {
                if (PagoBL.Instance.Insert(entity))
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
                entity.PagoId = _id;
                entity.EstadoId = Convert.ToString(comboBox1.SelectedValue);
                if (PagoBL.Instance.Update(entity))
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
    }
}
