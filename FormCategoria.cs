using BE;
using BL;
using Microsoft.VisualBasic;
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
    public partial class FormCategoria: Form
    {
        CategoriaBL categoriaBL;
        public FormCategoria()
        {
            categoriaBL = new CategoriaBL();
            InitializeComponent();
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns["Id"].Visible=false;
            dataGridView1.Columns.Add("Nombre", "Nombre");

            dataGridView1.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Actualizar();
        }
        void Actualizar()
        {
            dataGridView1.Rows.Clear();
            foreach(Categoria c in (new CategoriaBL().ListadoCategoria()))
            {
                dataGridView1.Rows.Add(c.Id,c.Nombre);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string texto = Interaction.InputBox("Ingresar Nombre Categoria: ");
            if (!String.IsNullOrEmpty(texto))
            {
                Categoria c = new Categoria();
                c.Nombre = texto;
                categoriaBL.AgregarCategoria(c);
                MessageBox.Show("Se Agrego Categoria");
                Actualizar();
            }
            else
            {
                MessageBox.Show("error");
            }
        }
    }
}
