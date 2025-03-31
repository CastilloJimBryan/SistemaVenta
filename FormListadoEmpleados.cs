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
    public partial class FormListadoEmpleados: Form
    {
        public FormListadoEmpleados()
        {
            InitializeComponent();
        }

        private void FormListadoEmpleados_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Apellido", "Apellido");
            dataGridView1.Columns.Add("DNI", "DNI");
            dataGridView1.Columns.Add("Telefono", "Telefono");
            dataGridView1.Columns.Add("Correo", "Correo");
            dataGridView1.Columns.Add("Estado", "Estado");

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            Actualizar();
        }
        void Actualizar()
        {
            dataGridView1.Rows.Clear();
            foreach (Usuario u in (new UsuarioBL().ListarEmpleados()))
            {
                dataGridView1.Rows.Add(u.Id, u.Nombre, u.Apellido, u.DNI, u.Telefono, u.Correo, u.Estado ? "Activo":"No Activo");
            }
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.SelectedRows[0].Selected = false;
                dataGridView1.SelectedRows[0].Visible = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormABMUsuario formABMUsuario = new FormABMUsuario();
            formABMUsuario.StartPosition=FormStartPosition.CenterScreen;
            formABMUsuario.TipoOperacion= Constantes.Operacion.Agregar;
            formABMUsuario.MdiParent=this.MdiParent;
            formABMUsuario.Show();
            Actualizar();
        }
    }
}
