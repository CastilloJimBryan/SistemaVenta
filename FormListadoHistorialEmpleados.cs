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
    public partial class FormListadoHistorialEmpleados: Form
    {
        public FormListadoHistorialEmpleados()
        {
            InitializeComponent();
        }
        internal Usuario UsuarioSeleccionado { get; set; }
        private void FormListadoHistorialEmpleados_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Id", "Id");
            //dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("IdOriginal", "IdOriginal");
            //dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Apellido", "Apellido");
            dataGridView1.Columns.Add("DNI", "DNI");
            dataGridView1.Columns.Add("Correo", "Correo");
            dataGridView1.Columns.Add("Telefono", "Telefono");
            dataGridView1.Columns.Add("Estado", "Estado");
            dataGridView1.Columns.Add("Fecha", "Fecha");

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoGenerateColumns = false;

            foreach (HistorialUsuario item in (new UsuarioBL().ListarHistorial(UsuarioSeleccionado.Id)))
            {
                dataGridView1.Rows.Add(item.Id, item.IdOriginal, item.Nombre, item.Apellido, item.DNI, item.Correo, item.Telefono, item.Estado ?"Activo":"No Activo", item.Fecha);
            }
        }
    }
}
