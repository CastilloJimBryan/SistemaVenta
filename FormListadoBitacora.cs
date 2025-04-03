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
    public partial class FormListadoBitacora: Form
    {
        public FormListadoBitacora()
        {
            InitializeComponent();
        }

        private void FormListadoBitacora_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns.Add("UsuarioId", "UsuarioId");
            dataGridView1.Columns["UsuarioId"].Visible = false;
            dataGridView1.Columns.Add("Usuario", "Usuario");
            dataGridView1.Columns.Add("Actividad", "Actividad");
            dataGridView1.Columns.Add("Fecha", "Fecha");

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;

            Actualizar();
        }
        void Actualizar()
        {
            dataGridView1.Rows.Clear();
            foreach (Bitacora b in (new BitacoraBL().ListadoBitacora()))
            {
                dataGridView1.Rows.Add(b.Id, b.UsuarioId, b.Usuario, b.Actividad, b.Fecha);
            }
        }
    }
}
