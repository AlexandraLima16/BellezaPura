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
    public partial class FormCategoriasNuevo : Form
    {
        private int _id = 0;
        public FormCategoriasNuevo()
        {
            InitializeComponent();
            this.Text = "Editar Categoria";
        }
        public FormCategoriasNuevo(Categoria entity)
        {
            InitializeComponent();
            comboBox1.Enabled = true;
            UpdateCombo();

            this.Text = "Modificar Categoria";
            _id = entity.CategoriaId;
            textBox1.Text = entity.NombreCategoria;

            comboBox1.SelectedValue = entity.EstadoId;
        }

        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "NombreEstado";
            //Propiedad de la llave  entity 
            comboBox1.ValueMember = "EstadoId";
            comboBox1.DataSource = EstadoBL.Instance.SelecAll();

        }

        private void FormCategoriasNuevo_Load(object sender, EventArgs e)
        {
            UpdateCombo();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Categoria entity = new Categoria()
            {
                NombreCategoria = textBox1.Text.Trim(),
                EstadoId = (int)comboBox1.SelectedValue
            };

            //Nuevo
            if (_id == 0)
            {
                if (CategoriaBL.Instance.Insert(entity))
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
                entity.CategoriaId = _id;
                entity.EstadoId = (int)comboBox1.SelectedValue;
                if (CategoriaBL.Instance.Update(entity))
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
