using BL;
using Servicio;
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
  
    public partial class FormMenu: Form
    {
        LoginBL loginBL;
        public FormMenu()
        {
            loginBL = new LoginBL();
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
           
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            ValidarFormulario();
        }

        void ValidarFormulario()
        {
            if(ManejoSesion.IsLoggin())
            {
                toolStripStatusLabel1.Text = "Usuario: ";
                toolStripStatusLabel2.Text = ManejoSesion.GetSesion.usuario.Nombre;
                toolStripStatusLabel3.Text = ManejoSesion.GetSesion.usuario.Apellido;
            }
           
            iniciarSesionToolStripMenuItem.Enabled = !ManejoSesion.IsLoggin();
            cerrarSesionToolStripMenuItem.Enabled = ManejoSesion.IsLoggin();


        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginBL.Logout();
            Application.Restart();
        }

        private void listadoEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListadoEmpleados formListadoEmpleados = new FormListadoEmpleados();
            formListadoEmpleados.StartPosition= FormStartPosition.CenterScreen;
            formListadoEmpleados.MdiParent = this;
            formListadoEmpleados.Show();
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListadoBitacora formListadoBitacora = new FormListadoBitacora();
            formListadoBitacora.StartPosition= FormStartPosition.CenterScreen;
            formListadoBitacora.MdiParent= this;
            formListadoBitacora.Show();
        }

        private void listadoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListadoProducto formListadoProducto = new FormListadoProducto();
            formListadoProducto.StartPosition = FormStartPosition.CenterScreen;
            formListadoProducto.MdiParent = this;
            formListadoProducto.Show();
        }

        private void listadoCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCategoria formCategoria = new FormCategoria();
            formCategoria.StartPosition= FormStartPosition.CenterScreen;
            formCategoria.MdiParent=this;
            formCategoria.Show();
        }
    }
}
