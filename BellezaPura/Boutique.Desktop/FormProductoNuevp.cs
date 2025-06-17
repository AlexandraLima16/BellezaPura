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

namespace Boutique.Desktop
{
    public partial class FormProductoNuevp : Form
    {
        private int _id = 0;
        public FormProductoNuevp()
        {
            InitializeComponent();
            this.Text = "Editar Producto";

        }
        public FormProductoNuevp(Producto entity)
        {
            InitializeComponent();
            this.Text = "Editar Producto";
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            UpdateCombo();

            _id = entity.ProductoId;
            textBox1.Text = entity.Nombre;
            textBox2.Text = entity.Descripcion;
            textBox3.Text = entity.Precio.ToString();
            DatePicker1.Value = entity.FechaIngreso;
            comboBox1.SelectedValue = entity.MarcaId;
            comboBox2.SelectedValue = entity.CategoriaId;
            comboBox3.SelectedValue = entity.EstadoId;


        }

        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "NombreMarca";
            //Propiedad de la llave  entity 
            comboBox1.ValueMember = "MarcaId";
            comboBox1.DataSource = MarcaBL.Instance.SelecAll();

            comboBox2.DisplayMember = "NombreCategoria";
            //Propiedad de la llave  entity 
            comboBox2.ValueMember = "CategoriaId";
            comboBox2.DataSource = CategoriaBL.Instance.SelecAll();

            comboBox3.DisplayMember = "NombreEstado";
            //Propiedad de la llave  entity 
            comboBox3.ValueMember = "EstadoId";
            comboBox3.DataSource = EstadoBL.Instance.SelecAll();
        }

        private void FormProductoNuevp_Load(object sender, EventArgs e)
        {
            UpdateCombo();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Producto entity = new Producto()
            {

                Nombre = textBox1.Text.Trim(),
                Descripcion = textBox2.Text.Trim(),
                Precio = Convert.ToDecimal(textBox3.Text.Trim()),
                FechaIngreso = DatePicker1.Value.Date,
                MarcaId = Convert.ToString(comboBox1.SelectedValue),
                CategoriaId = Convert.ToString(comboBox2.SelectedValue),
                EstadoId = Convert.ToString(comboBox3.SelectedValue)

                
                 };

                
                if (_id == 0)
                {
                   if (ProductoBL.Instance.Insert(entity))
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
                   entity.ProductoId = _id;
                entity.MarcaId = comboBox1.SelectedValue.ToString();
                entity.CategoriaId = comboBox2.SelectedValue.ToString();
                entity.EstadoId = comboBox3.SelectedValue.ToString();
                if (ProductoBL.Instance.Update(entity))
                {
                       MessageBox.Show("Registro hasido editado con exito!", "Confirmacion",
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

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
