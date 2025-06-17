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
    public partial class FormNuevoEstadoDev : Form
    {
        private int _id = 0;
        public FormNuevoEstadoDev()
        {
            InitializeComponent();
        }
        public FormNuevoEstadoDev(EstadoDev entity)
        {
            InitializeComponent();


            this.Text = "Modificar Categoria";
            _id = entity.EstadoDevId;

            textBox1.Text = entity.NombreEstadoDev;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            EstadoDev entity = new EstadoDev()
            {
                NombreEstadoDev = textBox1.Text.Trim()
            };

            //Nuevo
            if (_id == 0)
            {
                if (EstadoDevBL.Instance.Insert(entity))
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
                entity.EstadoDevId = _id;
                if (EstadoDevBL.Instance.Update(entity))
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
