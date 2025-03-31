using BE;
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
        public FormABMUsuario()
        {
            InitializeComponent();
        }
        internal Usuario UsuarioEditar { get;set; }
        internal Constantes.Operacion TipoOperacion { get; set; }
        private void FormABMUsuario_Load(object sender, EventArgs e)
        {
            Inicializar();

        }
        void Inicializar()
        {
            switch (TipoOperacion)
            {
                case Constantes.Operacion.Agregar:
                    BtnAceptar.Text = "Agregar";
                    break;
                case Constantes.Operacion.Modificar:
                    break;
                case Constantes.Operacion.Ver:
                    break;
                case Constantes.Operacion.Eliminar:
                    break;
                default:
                    break;
            }
        }
        void completarCampos(Usuario u)
        {

        }
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            switch (TipoOperacion)
            {
                case Constantes.Operacion.Agregar:
                    if (UsuarioEditar == null)
                        UsuarioEditar = new Usuario();
                    completarCampos (UsuarioEditar);
                    //revisar estoy recien en agregar .
                    break;
                case Constantes.Operacion.Modificar:
                    break;
                case Constantes.Operacion.Ver:
                    break;
                case Constantes.Operacion.Eliminar:
                    break;
                default:
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
