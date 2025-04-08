using BE;
using BL;
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
    public partial class FormListadoProducto: Form
    {
        ProductoBL productoBL;
        public FormListadoProducto()
        {
            productoBL = new ProductoBL();
            InitializeComponent();
        }

        private void FormListadoProducto_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Id","Id");
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns.Add("Codigo","Codigo");
            dataGridView1.Columns.Add("Nombre","Nombre");
            dataGridView1.Columns.Add("Descripcion","Descripcion");
            dataGridView1.Columns.Add("Categoria","Categoria");
            dataGridView1.Columns.Add("Precio Compra","Precio Compra");
            dataGridView1.Columns.Add("Precio Venta","Precio Venta");
            dataGridView1.Columns.Add("Cantidad Minima","Cantidad Minima");
            dataGridView1.Columns.Add("Cantidad Maxima","Cantidad Maxima");

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            Actualizar();
        }
        void Actualizar()
        {
            dataGridView1.Rows.Clear();
            foreach (Producto p in (new ProductoBL().ListarProducto()))
            {
                dataGridView1.Rows.Add(p.Id,p.Codigo,p.Nombre,p.Descripcion,p.Categoria,p.PrecioCompra,p.PrecioVenta,p.CantidadMinima,p.CantidadMaxima);
            }
           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormABMProducto formABMProducto = new FormABMProducto();
            formABMProducto.StartPosition= FormStartPosition.CenterScreen;
            formABMProducto.TipoOperacion= Constantes.Operacion.Agregar;
            formABMProducto.ShowDialog();
            Actualizar();
        }
        private void btnVer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                int mid = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                FormABMProducto formABMProducto = new FormABMProducto();
                formABMProducto.StartPosition = FormStartPosition.CenterScreen;
                formABMProducto.ProductoEditar=productoBL.VerProductoId(mid);
                formABMProducto.TipoOperacion = Constantes.Operacion.Ver;
                formABMProducto.ShowDialog();
                Actualizar();
            }
            else
            {
                MessageBox.Show("Debe Elegir Algun Producto");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count>0)
            {
                int mid = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                FormABMProducto formABMProducto = new FormABMProducto();
                formABMProducto.StartPosition = FormStartPosition.CenterScreen;
                formABMProducto.TipoOperacion = Constantes.Operacion.Modificar;
                formABMProducto.ShowDialog();
                Actualizar();
            }
            else
            {
                MessageBox.Show("Debe Elegir Algun Producto");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                int mid = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                FormABMProducto formABMProducto = new FormABMProducto();
                formABMProducto.StartPosition = FormStartPosition.CenterScreen;
                formABMProducto.TipoOperacion = Constantes.Operacion.Eliminar;
                formABMProducto.ShowDialog();
                Actualizar();
            }
            else
            {
                MessageBox.Show("Debe Elegir Algun Producto");
            }
        }

    }
}
