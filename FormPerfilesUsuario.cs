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
    public partial class FormPerfilesUsuario: Form
    {
        UsuarioBL usuarioBL;
        ComponenteBL componenteBL;
        Usuario temporal;
        Usuario seleccion;
        public FormPerfilesUsuario()
        {
            usuarioBL = new UsuarioBL();
            componenteBL = new ComponenteBL();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPerfilesUsuario_Load(object sender, EventArgs e)
        {
            configuracionCombox();

            btnCerrar.BackColor = Color.Red;
            btnGuardar.BackColor=Color.AliceBlue;
        }

        void configuracionCombox()
        {
            List<Usuario> listUser = usuarioBL.ListarEmpleados();
            List<Rol> listRol = componenteBL.ListadoRol();
            List<Accion> listAccion = componenteBL.ListadoAccion();

            cbxUsuario.DataSource= listUser;
            cbxUsuario.DisplayMember = "Nombre";
            cbxUsuario.ValueMember = "Id";
            cbxRol.DataSource= listRol;
            cbxRol.ValueMember = "Nombre";
            cbxRol.ValueMember = "Id";
            cbxAccion.DataSource= listAccion;
            cbxAccion.ValueMember = "Id";
            cbxAccion.DisplayMember = "Nombre";
        }
        void llenarTreview(TreeNode t,Componente c)
        {
            TreeNode n = new TreeNode(c.Nombre);
            n.Tag = c;
            t.Nodes.Add(n);
            foreach (var item in c.Componentes)
            {
                llenarTreview(n, item);
            }
        }
        void MostrarUsuario(Usuario u)
        {
            this.treeView1.Nodes.Clear();
            TreeNode t = new TreeNode(u.Nombre);
            foreach (var a in u.ComponenteList)
            {
                llenarTreview(t, a);
            }
            this.treeView1.Nodes.Add(t);
            this.treeView1.ExpandAll();
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            seleccion = (Usuario)this.cbxUsuario.SelectedItem;
            temporal = new Usuario()
            {
                Id = seleccion.Id,
                Nombre = seleccion.Nombre,
                Apellido = seleccion.Apellido,
                Clave = seleccion.Clave,
                Correo = seleccion.Correo,
                DNI = seleccion.DNI,
                Telefono = seleccion.Telefono,
            };
            ///
            MostrarUsuario(temporal);
        }

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            if(temporal!=null)
            {
                var Srol=(Rol)this.cbxRol.SelectedItem;
                if (Srol != null)
                {
                    var existe=false;
                    foreach (var item in temporal.ComponenteList)
                    {
                        if(componenteBL.ExisteRol(item,Srol.Id))
                        {
                            existe = true;
                        }
                    }
                    if (existe)
                    {
                        MessageBox.Show("Rol ya Asignado!");
                    }
                    else
                    {
                        ////
                        temporal.ComponenteList.Add(Srol);
                        MostrarUsuario(temporal);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe Elegir unusuario");
            }
        }
    }
}
