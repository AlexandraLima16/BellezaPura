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
    public partial class FormVentas : Form
    {
        private List <Cliente> _clientes;
        private List<Producto> _productos;
        private Usuario _user = null;
        private List<VentasGrid> _ventaGrid;
        Cliente clienteSeleccionado = null;
        public FormVentas(Usuario _entity)
        {
            InitializeComponent();
            _ventaGrid = new List<VentasGrid>();
            _user = _entity;

            txtUsuario.Text = string.Format($"{_user.Nombre}");
        }

        
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemColor.SecundaryColor;
                }
            }
        }
       

        private void FormVentas_Load(object sender, EventArgs e)
        {
            LoadTheme();
            UpdateGrid();
            Config();
        }
        private void UpdateGrid()
        {
            _clientes = ClienteBL.Instance.SelecAll();
            _productos = ProductoBL.Instance.SelecAll();
        }
        private void Config()
        {
            txtCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;


            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            AutoCompleteStringCollection autoCompleteCollectionProducto = new AutoCompleteStringCollection();

            foreach (var cliente in _clientes)
            {
                autoCompleteCollection.Add(string.Format($"{cliente.Nombres} {cliente.Apellidos} | {cliente.ClienteId}"));
            }

            foreach (var p in _productos)
            {
                autoCompleteCollectionProducto.Add(string.Format($"{p.Nombre} | {p.ProductoId}"));
            }

            txtCliente.AutoCompleteCustomSource = autoCompleteCollection;
            txtProducto.AutoCompleteCustomSource = autoCompleteCollectionProducto;


        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        Producto productos = null;
        int id = -1;
        int cantidad = 0;

        private void NDCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (productos != null)
            {
                cantidad = Convert.ToInt32(NDCant.Value);

                decimal subtotal = productos.Precio * cantidad;

                txtSubTotal.Text = subtotal.ToString();

            }
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            CargarProducto();
        }


        private void CargarProducto()
        {
            string text = txtProducto.Text;
            int pos = text.IndexOf('|');
            

            // Si está vacío o mal escrito, limpiar
            if (string.IsNullOrWhiteSpace(text) || pos < 0 || !int.TryParse(text.Substring(pos + 2).Trim(), out id))
            {
                LimpiarProducto();
                return;
            }

            // Buscar el producto por ID
            productos = _productos.FirstOrDefault(x => x.ProductoId == id);
            if (productos != null)
            {
                txtNombre.Text = productos.Nombre;
                txtPrecio.Text = productos.Precio.ToString("0.00");
                
                cantidad = Convert.ToInt32(NDCant.Value);
                decimal subtotal = productos.Precio * cantidad;
                txtSubTotal.Text = subtotal.ToString("0.00");
            }
            else
            {
                LimpiarProducto();
            }
        }

        private void LimpiarProducto()
        {
            productos = null;
            txtNombre.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtSubTotal.Text = string.Empty;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            VentasGrid venta = new VentasGrid()
            {
                ProductoId = id,
                Nombre = productos.Nombre,
                PrecioUnitario= productos.Precio,
                Cantidad = cantidad,
                SubTotal = productos.Precio * cantidad
            };

          
            for (int i = 0; i < _ventaGrid.Count; i++)
            {
                if (_ventaGrid[i].ProductoId== venta.ProductoId)
                {
                    _ventaGrid[i].Cantidad += venta.Cantidad;
                    _ventaGrid[i].SubTotal = _ventaGrid[i].PrecioUnitario*_ventaGrid[i].Cantidad;
                }
                
            }
            var query = _ventaGrid.FirstOrDefault(x => x.ProductoId == venta.ProductoId);
            if (query == null)
            {
                _ventaGrid.Add(venta);
            }

            //Metodo de extension de LinQ
            lbTotal.Text = _ventaGrid.Sum(x => x.SubTotal).ToString();
            NDCant.Value = 1;


            dataGridView1.DataSource = _ventaGrid.ToList();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            List<DetVenta> _detalle = new List<DetVenta>();
            Venta venta = new Venta();
            venta.Fecha = DateTime.Now;
            venta.Total = _ventaGrid.Sum(x => x.SubTotal);
            venta.ClienteId = clienteSeleccionado.ClienteId;
            venta.DUI = _user.DUI;


            foreach (var item in _ventaGrid)
            {
                DetVenta entity = new DetVenta()
                {
                    ProductoId = item.ProductoId,
                    PrecioUnitario = item.PrecioUnitario,
                    Cantidad = item.Cantidad,
                    SubTotal = item.SubTotal,
                    VentaId = 0
                };

                _detalle.Add(entity);
            }

            DialogResult dr = MessageBox.Show("¿Desea guardar la venta?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                VentaBL.Instance.Insert(venta, _detalle);
                MessageBox.Show("Venta guardada con exito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            // Limpiar después de pagar
            _ventaGrid.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _ventaGrid.ToList(); // Refrescar vacío

            // Limpiar campos de producto
            txtProducto.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtSubTotal.Text = "";

            // Limpiar campos de cliente
            txtCliente.Text = "";

            // Resetear cantidad
            NDCant.Value = 1;

            // Limpiar total
            lbTotal.Text = "0.00";
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {

            CargarCliente();
        }

        private void CargarCliente()
        {

            string texto = txtCliente.Text;
            int pos = texto.IndexOf('|');

            if (string.IsNullOrWhiteSpace(texto) || pos < 0 || !int.TryParse(texto.Substring(pos + 2).Trim(), out int clienteId))
            {
                clienteSeleccionado = null;
                return;
            }

            clienteSeleccionado = _clientes.FirstOrDefault(c => c.ClienteId == clienteId);
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Borrar")
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea quitar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Elimina el producto de la lista
                    _ventaGrid.RemoveAt(e.RowIndex);

                    // Refresca el DataGridView
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = _ventaGrid.ToList();

                    // Actualiza el total
                    lbTotal.Text = _ventaGrid.Sum(x => x.SubTotal).ToString("0.00");
                }
            }
        }
    }
    //Viuw Model
    public class VentasGrid
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }

    }
}
