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
        UsuarioBL usuarioBL;
        public FormListadoEmpleados()
        {
            usuarioBL = new UsuarioBL();
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
            dataGridView1.AutoSizeColumnsMode= DataGridViewAutoSizeColumnsMode.Fill;

            Actualizar();
        }
        private void Actualizar()
        {
            dataGridView1.Rows.Clear();
            foreach (Usuario u in (new UsuarioBL().ListarEmpleados()))
            {
                dataGridView1.Rows.Add(u.Id, u.Nombre, u.Apellido, u.DNI, u.Telefono, u.Correo, u.Estado ? "Activo":"No Activo");
            }
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Visible = false;
                dataGridView1.Rows[0].Selected=false;
            }
        }
        void Filtrar()
        {
            List<Usuario> filtro = usuarioBL.ListarEmpleados();
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                filtro = filtro.FindAll(u => u.Nombre.StartsWith(textBox1.Text, StringComparison.OrdinalIgnoreCase));
            }

            dataGridView1.Rows.Clear();

            foreach(var u in  filtro)
            {
                if (u.Id != 1)
                {
                    dataGridView1.Rows.Add(u.Id, u.Nombre, u.Apellido, u.DNI, u.Telefono, u.Correo, u.Estado ? "Activo" : "No Activo");
                }
            }
            
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormABMUsuario formABMUsuario = new FormABMUsuario();
            formABMUsuario.StartPosition=FormStartPosition.CenterScreen;
            formABMUsuario.TipoOperacion= Constantes.Operacion.Agregar;
            formABMUsuario.ShowDialog();
            Actualizar();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int mid = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                FormABMUsuario formABMUsuario = new FormABMUsuario();
                formABMUsuario.StartPosition = FormStartPosition.CenterScreen;
                formABMUsuario.TipoOperacion = Constantes.Operacion.Ver;
                formABMUsuario.UsuarioEditar = usuarioBL.VerUsuarioId(mid);
                formABMUsuario.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe Elegir Empleado a ver");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int mid = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                FormABMUsuario formABMUsuario = new FormABMUsuario();
                formABMUsuario.StartPosition = FormStartPosition.CenterScreen;
                formABMUsuario.TipoOperacion = Constantes.Operacion.Modificar;
                formABMUsuario.UsuarioEditar= usuarioBL.VerUsuarioId(mid) ;
                formABMUsuario.ShowDialog();
                Actualizar();
            }
            else
            {
                MessageBox.Show("Elegir Usuario a Editar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int mid = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                FormABMUsuario formABMUsuario = new FormABMUsuario();
                formABMUsuario.StartPosition = FormStartPosition.CenterScreen;
                formABMUsuario.TipoOperacion = Constantes.Operacion.Eliminar;
                formABMUsuario.UsuarioEditar = usuarioBL.VerUsuarioId(mid);
                formABMUsuario.ShowDialog();
                Actualizar();
            }
            else
            {
                MessageBox.Show("Elegir Usuario a Eliminar");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
    }
}
