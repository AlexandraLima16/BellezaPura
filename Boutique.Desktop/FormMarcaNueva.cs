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
    public partial class FormMarcaNueva : Form
    {
        private int _id = 0;
        public FormMarcaNueva()
        {
            InitializeComponent();
        }
        public FormMarcaNueva(Marca entity)
        {
            InitializeComponent();

            this.Text = "Modificar Marca";
            _id = entity.MarcaId;

            textBoxMarca.Text = entity.NombreMarca;
            
        }

        private void FormMarcaNueva_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Marca entity = new Marca()
            {
                NombreMarca = textBoxMarca.Text.Trim()
            };

            //Nuevo
            if (_id == 0)
            {
                if (MarcaBL.Instance.Insert(entity))
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
                entity.MarcaId = _id;
                if (MarcaBL.Instance.Update(entity))
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
