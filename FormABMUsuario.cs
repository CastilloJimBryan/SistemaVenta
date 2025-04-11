using BE;
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
    public partial class FormABMUsuario: Form
    {
        UsuarioBL usuarioBL;
        public FormABMUsuario()
        {
            usuarioBL = new UsuarioBL();
            InitializeComponent();
        }
        internal Usuario UsuarioEditar { get;set; }
        internal Constantes.Operacion TipoOperacion { get; set; }
        private void FormABMUsuario_Load(object sender, EventArgs e)
        {
            Inicializar();
            textBox7.UseSystemPasswordChar = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            cbxActivo.Visible = false;
            btnCancelar.Text = "Cerrar";

        }
        void Inicializar()
        {
            switch (TipoOperacion)
            {
                case Constantes.Operacion.Agregar:
                    BtnAceptar.Text = "Agregar";
                    BtnAceptar.BackColor=Color.LightBlue;
                    groupBox1.Text = "Registrar Usuario";
                    break;
                case Constantes.Operacion.Modificar:
                    if(UsuarioEditar==null)
                    {
                        MessageBox.Show("No hay Empleado");
                    }
                    BtnAceptar.Text = "Editar";
                    groupBox1.Text = "Editar Usuario";
                    CargarDatos(UsuarioEditar);
                    break;
                case Constantes.Operacion.Ver:
                    cbxActivo.Visible = true;
                    BtnAceptar.Visible = false;
                    groupBox1.Text = "Datos del Usuario";
                    if (UsuarioEditar == null)
                    {
                        MessageBox.Show("No hay Empleado");
                    }
                    SoloLectura();
                    CargarDatos(UsuarioEditar);
                    break;
                case Constantes.Operacion.Eliminar:
                    if(UsuarioEditar == null)
                    {
                        MessageBox.Show("No hay Empleado");
                    }
                    BtnAceptar.Text = "Eliminar?";
                    BtnAceptar.BackColor=Color.Red;
                    groupBox1.Text = "Eliminar Usuario";
                    SoloLectura();
                    CargarDatos(UsuarioEditar);
                    break;
                default:
                    break;
            }
        }
        void SoloLectura()
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            cbxActivo.Enabled = false;
        }
        void CargarDatos(Usuario u)
        {
            textBox1.Text=u.Nombre;
            textBox2.Text=u.Apellido;
            textBox3.Text=u.DNI.ToString();
            textBox4.Text=u.Correo.ToString();
            textBox5.Text=u.Telefono.ToString();
            cbxActivo.Checked = u.Estado;
        }

        void CompletarCampos(Usuario u)
        {
            u.Nombre = textBox1.Text;
            u.Apellido= textBox2.Text;
            u.DNI=int.Parse(textBox3.Text);
            u.Correo= textBox4.Text;
            u.Telefono=int.Parse(textBox5.Text);
            u.Clave = Encriptacion.Hash(textBox3.Text);
        }
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            switch (TipoOperacion)
            {
                case Constantes.Operacion.Agregar:
                    if (UsuarioEditar == null)
                        UsuarioEditar = new Usuario();
                    CompletarCampos (UsuarioEditar);
                    UsuarioEditar.Estado=false;
                    usuarioBL.AgregarUsuario(UsuarioEditar);
                    MessageBox.Show("Se Agrego Correctamente!");
                    this.Close();
                    break;
                case Constantes.Operacion.Modificar:
                    usuarioBL.AgregarAHistorial(UsuarioEditar);
                    CompletarCampos(UsuarioEditar);
                    usuarioBL.EditarUsuario(UsuarioEditar);
                    MessageBox.Show("Se Agrego al Historial de Cambios");
                    MessageBox.Show("Se Modifico Correctamente!");
                    this.Close();
                    break;
                case Constantes.Operacion.Eliminar:
                    List<HistorialUsuario> list=usuarioBL.ListarHistorial(UsuarioEditar.Id);
                    if (list.Count > 0)
                    {
                        HistorialUsuario hu = new HistorialUsuario();
                        hu.IdOriginal = list[0].IdOriginal;
                        if (UsuarioEditar.Id.Equals(hu.IdOriginal))
                        {
                            usuarioBL.EliminarDelHistorial(hu);
                        }
                    }
                    usuarioBL.EliminarUsuario(UsuarioEditar);
                    MessageBox.Show("Se Elimino Correctamente");
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text=textBox1.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox7.Text=textBox3.Text;
        }
    }
}
