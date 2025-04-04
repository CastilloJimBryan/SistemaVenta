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
        BitacoraBL bitacoraBL;
        public FormListadoBitacora()
        {
            bitacoraBL = new BitacoraBL();
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
            dateTimePicker1.Visible = false;

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

        void filtrar()
        {
            List<Bitacora> listad=bitacoraBL.ListadoBitacora();

            if(rbusuario.Checked)
            {
                listad=listad.FindAll(u=>u.Usuario.StartsWith(textBox1.Text, StringComparison.OrdinalIgnoreCase));
            }
            else if (rbactividad.Checked)
            {
                listad = listad.FindAll(a => a.Actividad.StartsWith(textBox1.Text, StringComparison.OrdinalIgnoreCase));
            }
            if (rbfecha.Checked)
            {
                DateTime fechaSeleccionada = dateTimePicker1.Value.Date;
                listad=listad.FindAll(f=>f.Fecha.Date==fechaSeleccionada);
            }

            dataGridView1.Rows.Clear();

            foreach(var b in listad)
            {
                dataGridView1.Rows.Add(b.Id, b.UsuarioId, b.Usuario, b.Actividad, b.Fecha);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void rbfecha_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = true;
            textBox1.Visible = false;
        }

        private void rbusuario_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dateTimePicker1.Visible = false;
            textBox1.Visible = true;
        }

        private void rbactividad_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dateTimePicker1.Visible = false;
            textBox1.Visible = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            filtrar();
        }
    }
}
