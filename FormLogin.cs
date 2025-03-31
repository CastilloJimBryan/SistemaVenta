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
    public partial class FormLogin: Form
    {
        LoginBL loginBL;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                loginBL = new LoginBL();
                loginBL.Login(textBox1.Text, textBox2.Text);
                MessageBox.Show("Ingreso Correctamente!!");
                FormMenu formMenu=new FormMenu();
                //formMenu.Size= new Size(1320, 670);
                formMenu.WindowState = FormWindowState.Maximized;
                formMenu.StartPosition = FormStartPosition.CenterScreen;
                formMenu.ShowDialog();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxmostrarcontraseña_CheckedChanged(object sender, EventArgs e)
        {
           textBox2.UseSystemPasswordChar=!cbxmostrarcontraseña.Checked;
            cbxmostrarcontraseña.Text = cbxmostrarcontraseña.Checked ? "Ocultar Contraseña" : "Mostrar Contraseña";
        }
    }
}
