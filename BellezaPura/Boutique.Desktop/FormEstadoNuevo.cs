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
    public partial class FormEstadoNuevo : Form
    {
        private int _id = 0;
        public FormEstadoNuevo()
        {
            InitializeComponent();
        }
        public FormEstadoNuevo(Estado entity)
        {
            InitializeComponent();

            this.Text = "Modificar Categoria";
            _id = entity.EstadoId;

            textBox1.Text = entity.NombreEstado;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Estado entity = new Estado()
            {
                NombreEstado = textBox1.Text.Trim()
            };

            //Nuevo
            if (_id == 0)
            {
                if (EstadoBL.Instance.Insert(entity))
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
                entity.EstadoId = _id;
                if (EstadoBL.Instance.Update(entity))
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

        private void FormEstadoNuevo_Load(object sender, EventArgs e)
        {

        }
    }
}
