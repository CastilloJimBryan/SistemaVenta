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
        public FormListadoProducto()
        {
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
                dataGridView1.Rows.Add(p.Id,p.Nombre,p.Descripcion,p.Categoria,p.PrecioCompra,p.PrecioVenta,p.CantidadMinima,p.CantidadMaxima);
            }
           
        }
    }
}
