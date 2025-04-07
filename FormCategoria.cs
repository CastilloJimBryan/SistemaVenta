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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int mid = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                Categoria c= categoriaBL.VerCategoria(mid);
                string textoEditado = Interaction.InputBox("Editar Categoria: ", "", c.Nombre);
                if (!String.IsNullOrEmpty(textoEditado))
                {
                    c.Nombre = textoEditado;
                    categoriaBL.EditarCategoria(c);
                    MessageBox.Show("Se Edito Categoria!");
                    Actualizar();

                }
                else
                {
                    MessageBox.Show("No se Edito Categoria");
                }
            }
            else
            {
                MessageBox.Show("Debe Elegir una Categoria");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count> 0)
            {
                int mid = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                Categoria c=categoriaBL.VerCategoria(mid);
                string textoEditado = Interaction.InputBox("Eliminar Categoria: ", "", c.Nombre);
                if (!String.IsNullOrEmpty(textoEditado))
                {
                    categoriaBL.EliminarCategoria(c);
                    MessageBox.Show("Se Elimino Categoria!");
                    Actualizar();

                }
                else
                {
                    MessageBox.Show("No se Elimino la Categoria");
                }
            }
            else
            {
                MessageBox.Show("Debe Elegir una Categoria");
            }
        }
    }
}
