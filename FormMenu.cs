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

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            //loginBL.Logout();
            Application.Restart();
        }

        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {

            //loginBL.Logout();
            Application.Restart();
        }
    }
}
