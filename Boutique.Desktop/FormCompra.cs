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
    public partial class FormCompra : Form
    {
        private List<Producto> _producto; 
        private List<Pago> _Pago;
        private List<Proveedor> _proveedor;
        private Usuario _user = null;
        public FormCompra(Usuario _entity)
        {
            InitializeComponent();
            _user = _entity;
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(System.Windows.Forms.Button))
                {
                    System.Windows.Forms.Button btn = (System.Windows.Forms.Button)btns;
                    btn.BackColor = ThemColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemColor.SecundaryColor;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FormCompra_Load(object sender, EventArgs e)
        {
            LoadTheme();
            UpdateGrid();
            Config();
        }

        private void Config()
        {
            txtProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtPoducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPoducto.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtPago.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPago.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            AutoCompleteStringCollection autoCompleteCollectionProducto = new AutoCompleteStringCollection();
            AutoCompleteStringCollection autoCompleteCollectionPago = new AutoCompleteStringCollection();


            foreach (var proveedor in _proveedor)
            {
                autoCompleteCollection.Add(string.Format($"{proveedor.Nombre}"));
            }

            foreach (var producto in _producto)
            {
                autoCompleteCollectionProducto.Add(string.Format($"{producto.Nombre} | {producto.ProductoId}"));
            }

            foreach (var pago in _Pago)
            {
                autoCompleteCollectionPago.Add(string.Format($"{pago.TipoPago} | {pago.PagoId}"));
            }

            txtProveedor.AutoCompleteCustomSource = autoCompleteCollection;
            txtPoducto.AutoCompleteCustomSource = autoCompleteCollectionProducto;
            txtPago.AutoCompleteCustomSource = autoCompleteCollectionPago;
        }

        private void UpdateGrid()
        {
            _producto = ProductoBL.Instance.SelecAll();
            _proveedor = ProveedorBL.Instance.SelecAll();
            _Pago = PagoBL.Instance.SelecAll();
        }



        Producto productos = null;
        Proveedor proveedores = null;
        Pago pagos = null;
        int id = -1;
        int cantidad = 0;
        private void NDCantidad_ValueChanged(object sender, EventArgs e)
        {
            CalcularSubTotal();


        }


        private void CalcularSubTotal()
        {

            if (productos != null)
            {
                int cantidad = (int)NDCantidad.Value;
                decimal subtotal = productos.Precio * cantidad;
                txtSubTotal.Text = subtotal.ToString("0.00");
            }
            else
            {
                txtSubTotal.Text = "0.00";
            }
        }
        private void CargarProducto()
        {
            // Cargar producto

            string text = txtPoducto.Text;
            int pos = text.IndexOf('|');


            // Si está vacío o mal escrito, limpiar
            if (string.IsNullOrWhiteSpace(text) || pos < 0 || !int.TryParse(text.Substring(pos + 2).Trim(), out id))
            {
                LimpiarProducto();
                return;
            }

            // Buscar el producto por ID
            productos = _producto.FirstOrDefault(x => x.ProductoId == id);
            if (productos != null)
            {
                txtPoducto.Text = productos.Nombre;
                txtPrecio.Text = productos.Precio.ToString("0.00");

                cantidad = Convert.ToInt32(NDCantidad.Value);
                decimal subtotal = productos.Precio * cantidad;
                txtSubTotal.Text = subtotal.ToString("0.00");
            }
            else
            {
                LimpiarProducto();
            }




            // Cargar proveedor
            string textoProveedor = txtProveedor.Text;
            var partesProveedor = textoProveedor.Split('|');
            if (partesProveedor.Length == 2 && int.TryParse(partesProveedor[1].Trim(), out int proveedorId))
            {
                proveedores = _proveedor.FirstOrDefault(x => x.ProveedorId == proveedorId);
            }


            // Cargar pago
            string textoPago = txtPago.Text;
            var partesPago = textoPago.Split('|');
            if (partesPago.Length == 2 && int.TryParse(partesPago[1].Trim(), out int pagoId))
            {
                pagos = _Pago.FirstOrDefault(x => x.PagoId == pagoId);
            }
        }

        private void LimpiarProducto()
        {
            productos = null;
            proveedores = null;
            pagos = null;
            txtPrecio.Text = string.Empty;
            txtSubTotal.Text = string.Empty;
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            CargarProducto();
        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
            CargarProducto();
        }

        private void txtPoducto_TextChanged(object sender, EventArgs e)
        {
            CargarProducto();
        }
    }
}
