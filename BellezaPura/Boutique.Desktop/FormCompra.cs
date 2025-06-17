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
        private List<Proveedor> _proveedor;
        private List<ComprasGrid> _comprasGrid;
        private Usuario _user = null;
        public FormCompra(Usuario _entity)
        {
            InitializeComponent();
            _user = _entity;
            txtUsuario.Text = string.Format($"{_user.Nombre}");
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

       

        private void FormCompra_Load(object sender, EventArgs e)
        {
            LoadTheme();
            UpdateGrid();
            Config();
            _comprasGrid = new List<ComprasGrid>();
            UpdateCombo();
            NDCantidad.Minimum = 1;
            NDCantidad.Value = 1;
        }

        private void UpdateCombo()
        {
            cbPago.DisplayMember = "TipoPago";
            cbPago.ValueMember = "PagoId";
            cbPago.DataSource = PagoBL.Instance.SelecAll();
        }

        private void Config()
        {
            txtProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtPoducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPoducto.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            AutoCompleteStringCollection autoCompleteCollectionProducto = new AutoCompleteStringCollection();


            foreach (var proveedor in _proveedor)
            {
                autoCompleteCollection.Add(string.Format($"{proveedor.Nombre}"));
            }

            foreach (var producto in _producto)
            {
                autoCompleteCollectionProducto.Add(string.Format($"{producto.Nombre} | {producto.ProductoId}"));
            }

            txtProveedor.AutoCompleteCustomSource = autoCompleteCollection;
            txtPoducto.AutoCompleteCustomSource = autoCompleteCollectionProducto;
        }

        private void UpdateGrid()
        {
            _producto = ProductoBL.Instance.SelecAll();
            _proveedor = ProveedorBL.Instance.SelecAll();
        }

        Producto productos = null;
        int id = -1;
        int cantidad = 0;

        private void txtPoducto_Validated(object sender, EventArgs e)
        {
            string text =txtPoducto.Text;
            int pos = text.IndexOf('|');
            if (pos > 0)
            {
                id = int.Parse(text.Substring(pos + 2).Trim());
                productos = _producto.FirstOrDefault(x=> x.ProductoId == id);
                if (productos!= null)
                {
                    txtPoducto.Text = productos.Nombre;
                }
            }
        }
        private void CalcularSubTotal()
        {

            if (productos == null) return;
            
            if(decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                int cantidad = (int)NDCantidad.Value;
                txtSubTotal.Text = (precio * cantidad).ToString("F2");
            }
            else
            {
                txtSubTotal.Text = "0.00";
            }
        }


        private void NDCantidad_ValueChanged(object sender, EventArgs e)
        {
            string texto = txtPoducto.Text.Trim();
            int separador = texto.IndexOf('|');
            string nombreProducto = (separador > 0) ? texto.Substring(0, separador).Trim() : texto;

            productos = _producto.FirstOrDefault(p =>
                p.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));


        }

         Proveedor proveedores = null;

        private void button1_Click(object sender, EventArgs e)
        {
            ActualizarGridConBoton();

            // Validar proveedor
            string textoProveedor = txtProveedor.Text.Trim();
            int posi = textoProveedor.IndexOf('|');
            string nombreProveedor = posi > 0 ? textoProveedor.Substring(0, posi).Trim() : textoProveedor;
            proveedores = _proveedor.FirstOrDefault(p =>
                p.Nombre.Equals(nombreProveedor, StringComparison.OrdinalIgnoreCase));
            if (proveedores == null)
            {
                MessageBox.Show("El proveedor ingresado no existe. Seleccione un producto válido.", "Advertencia");
                return;
            }


            string textoProducto = txtPoducto.Text.Trim();
            int pos = textoProducto.IndexOf('|');
            string nombreProducto = pos > 0 ? textoProducto.Substring(0, pos).Trim() : textoProducto;
            productos = _producto.FirstOrDefault(p =>
                p.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));

            if (productos == null)
            {
                MessageBox.Show("El producto ingresado no existe. Seleccione un producto válido.", "Advertencia");
                return;
            }

            txtPoducto.Text = productos.Nombre;
            txtProveedor.Text = proveedores.Nombre;

            // Obtener valores del usuario
            cantidad = (int)NDCantidad.Value;

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Ingrese un precio válido.", "Error");
                return;
            }
            int pagoId = (int)cbPago.SelectedValue;

            // Buscar si ya existe en el grid
            var existente = _comprasGrid.FirstOrDefault(x => x.ProductoId == productos.ProductoId);
            if (existente != null)
            {
                if (existente.Precio != precio)
                {
                    decimal nuevoPrecio = ((existente.Precio * existente.Cantidad) + (precio * cantidad)) /
                                          (existente.Cantidad + cantidad);
                    existente.Precio = Math.Round(nuevoPrecio, 2);
                }
                existente.Cantidad += cantidad;
            }
            else
            {
                _comprasGrid.Add(new ComprasGrid
                {
                    ProductoId = productos.ProductoId,
                    ProveedorId = proveedores.ProveedorId,
                    Precio = precio,
                    Pago = pagoId,
                    Cantidad = cantidad,


                });
            }

            ActualizarGridConBoton();
            dataGridView1.Columns["ProductoId"].Visible = false;
        }

        private void ActualizarGridConBoton()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _comprasGrid.ToList();
            AgregarColumnaDisminuir();
            lbTotal.Text = _comprasGrid.Sum(x => x.Subtotal).ToString("F2");
            

        }

        private void AgregarColumnaDisminuir()
        {
            if (!dataGridView1.Columns.Contains("Disminuir"))
            {
                DataGridViewImageColumn colDisminuir = new DataGridViewImageColumn();
                colDisminuir.Name = "Disminuir";
                colDisminuir.HeaderText = "Disminuir";
                colDisminuir.Image = Properties.Resources.circulo_cruzado__1_;
                colDisminuir.ImageLayout = DataGridViewImageCellLayout.Zoom;
                colDisminuir.Width = 100;
                dataGridView1.Columns.Add(colDisminuir);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Disminuir")
            {
                var fila = dataGridView1.Rows[e.RowIndex].DataBoundItem as ComprasGrid;

                if (fila != null)
                {
                    var item = _comprasGrid.FirstOrDefault(x => x.ProductoId == fila.ProductoId);
                    if (item != null)
                    {
                        item.Cantidad--;

                        if (item.Cantidad <= 0)
                        {
                            _comprasGrid.Remove(item);
                        }

                        ActualizarGridConBoton();
                    }
                }
            }
        }









        private void LimpiarProducto()
        {
            productos = null;
            proveedores = null;
            txtPrecio.Text = string.Empty;
            txtSubTotal.Text = string.Empty;
        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
            CalcularSubTotal();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            ActualizarGridConBoton();
            List<DetCompra> detalles = new List<DetCompra>();
            Compra compra = new Compra();

            if (proveedores == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor válido desde el botón 1.", "Advertencia");
                return;
            }
            compra.DUI = _user.DUI;
            compra.Fecha = DateTime.Now;
            compra.TotalCompra = _comprasGrid.Sum(x => x.Subtotal);


            foreach (var item in _comprasGrid)
            {
                DetCompra detalle = new DetCompra
                {
                    CompraId = 0,
                    ProductoId = item.ProductoId,
                    PagoId = item.Pago,
                    ProveedorId = item.ProveedorId,
                    Subtotal = item.Subtotal,
                    Cantidad = item.Cantidad,
                    Precio = item.Precio


                };

                detalles.Add(detalle);
            }

            try
            {
                DialogResult dr = MessageBox.Show("¿Está seguro de guardar la compra?", "Confirmación", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    int compraId = CompraBL.Instance.Insert(compra, detalles);
                    if (compraId > 0)
                    {
                        MessageBox.Show("¡Compra guardada exitosamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar la compra", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPoducto_TextChanged(object sender, EventArgs e)
        {
            CalcularSubTotal();
        }
    }

    public class ComprasGrid
    {
        public int ProductoId   { get; set; }
        public int ProveedorId { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => Precio * Cantidad;
        public int Pago { get; set; }

    }

}
