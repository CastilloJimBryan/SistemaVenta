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
    public partial class FormPerfiles: Form
    {
        ComponenteBL componenteBL;
        public FormPerfiles()
        {
            componenteBL = new ComponenteBL();
            InitializeComponent();
        }

        private void FormPerfiles_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView2.Columns.Add("Id", "Id");
            dataGridView2.Columns["Id"].Visible = false;
            dataGridView2.Columns.Add("Nombre", "Nombre");
            dataGridView2.SelectionMode= DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;

            MostrarRol();
            MostrarAccion();
        }
        void MostrarRol()
        {
            dataGridView1.Rows.Clear();
            foreach(Rol rol in (new ComponenteBL().ListadoRol())){
                dataGridView1.Rows.Add(rol.Id, rol.Nombre);
            }
        }
        void MostrarAccion()
        {
            dataGridView2.Rows.Clear();
            foreach (Accion a in (new ComponenteBL().ListadoAccion()))
            {
                dataGridView2.Rows.Add(a.Id, a.Nombre);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Componente r = new Rol()
            {
                Nombre = textBox1.Text,
            };
            componenteBL.AgregarComponente(r);
            MostrarRol();
            textBox1.Text = "";

        }

        private void btnAgrega_Click(object sender, EventArgs e)
        {
            Componente a = new Accion()
            {
                Nombre = textBox2.Text,
            };
            componenteBL.AgregarComponente(a);
            textBox2.Text = "";
            MostrarAccion();
        }
    }
}
