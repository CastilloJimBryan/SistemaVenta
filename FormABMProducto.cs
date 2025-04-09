using BE;
using BL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Venta
{
    public partial class FormABMProducto: Form
    {
        CategoriaBL categoriaBL;
        ProductoBL productoBL;
        public FormABMProducto()
        {
            categoriaBL = new CategoriaBL();
            productoBL = new ProductoBL();
            InitializeComponent();
            ListarCategoria();
        }
        internal Producto ProductoEditar {  get; set; }
        internal Constantes.Operacion TipoOperacion {  get; set; }
        private void FormABMProducto_Load(object sender, EventArgs e)
        {
            inicializar();
            btnCancelar.Text = "Cerrar";
        }
        void ListarCategoria()
        {
            List<Categoria> list=categoriaBL.ListadoCategoria();
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
        }
        void inicializar()
        {
            switch (TipoOperacion)
            {
                case Constantes.Operacion.Agregar:
                    gpxProducto.Text = "Registro de Productos";
                    btnAceptar.Text = "Agregar";

                    break;
                case Constantes.Operacion.Modificar:
                    gpxProducto.Text = "Edicion de Productos";
                    btnAceptar.Text = "Editar";
                    if(ProductoEditar==null)
                    {
                        MessageBox.Show("Error!");
                    }
                    TraerDatos(ProductoEditar);
                    break;
                case Constantes.Operacion.Ver:
                    gpxProducto.Text = "Datos de Productos";
                    btnAceptar.Visible = false;
                    if(ProductoEditar==null)
                    {
                        MessageBox.Show("Error!");
                    }
                    TraerDatos(ProductoEditar);
                    SoloLectura();
                    break;
                case Constantes.Operacion.Eliminar:
                    gpxProducto.Text = "Eliminar Producto";
                    btnAceptar.Text = "Eliminar";
                    btnAceptar.BackColor = Color.Red;
                    if(ProductoEditar==null)
                    {
                        MessageBox.Show("Error!");
                    }
                    TraerDatos(ProductoEditar);
                    SoloLectura();
                    break;
                default:
                    break;
            }
        }
        void SoloLectura()
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            comboBox1.Enabled = false;
        }
        void TraerDatos(Producto p)
        {
            textBox1.Text=p.Codigo.ToString();
            textBox2.Text=p.Nombre.ToString();
            textBox3.Text=p.Descripcion.ToString();
            textBox4.Text=p.PrecioCompra.ToString();
            textBox5.Text=p.PrecioVenta.ToString();
            textBox6.Text=p.CantidadMinima.ToString();
            textBox7.Text=p.CantidadMaxima.ToString();
            comboBox1.Text=p.Categoria;
        }

        Categoria comboSeleccionado;
        void CompletarCampos(Producto p)
        {
            p.Codigo=int.Parse(textBox1.Text);
            p.Nombre=textBox2.Text;
            p.Descripcion=textBox3.Text;
            p.PrecioCompra = int.Parse(textBox4.Text);
            p.PrecioVenta=int.Parse(textBox5.Text);
            p.CantidadMinima=int.Parse(textBox6.Text);
            p.CantidadMaxima=int.Parse(textBox7.Text);
            if (comboBox1.SelectedItem != null)
            {
                comboSeleccionado=(Categoria)comboBox1.SelectedItem;
                p.Categoria =comboSeleccionado.Id.ToString();
            }

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (TipoOperacion)
            {
                case Constantes.Operacion.Agregar:
                    if (ProductoEditar == null)
                    {
                        ProductoEditar = new Producto();
                    }
                    CompletarCampos(ProductoEditar);
                    ProductoEditar.AgregarCategoria(comboSeleccionado);
                    productoBL.AgregarProducto(ProductoEditar);
                    this.Close();
                    break;
                case Constantes.Operacion.Modificar:
                    if(ProductoEditar != null)
                    {
                        CompletarCampos(ProductoEditar);
                        productoBL.EditarRelacionProductoCategoria(ProductoEditar);
                        productoBL.EditarProducto(ProductoEditar);
                    }
                    this.Close();
                    break;
                case Constantes.Operacion.Eliminar:
                    if (ProductoEditar != null)
                    {
                        ProductoEditar.QuitarCategoria(comboSeleccionado);
                        productoBL.EliminarRelacionProductoCategoria(ProductoEditar);
                        productoBL.EliminarProducto(ProductoEditar);
                    }
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
