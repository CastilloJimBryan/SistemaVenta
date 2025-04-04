using BE;
using DA;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class LoginBL
    {
        UsuarioDAL usuarioDAL;
        BitacoraBL bitacoraBL;
        public LoginBL()
        {
            usuarioDAL = new UsuarioDAL();
            bitacoraBL = new BitacoraBL();
        }
        public void Login(string nom,string psw)
        {
            var hashpsw=Encriptacion.Hash(psw);
            if(String.IsNullOrEmpty(nom) && String.IsNullOrEmpty(psw))
            {
                throw new Exception("Campos Vacios!");
            }
            Usuario u = usuarioDAL.ObtenerUserPass(nom, hashpsw);
            if(u == null) { throw new Exception("Usuario / Contraseña Incorrecto!");  }
            ManejoSesion.LogIn(u);

            //bitacoraBL.AgregarBitacora(u, "Inicio Sesion");
        }
        public void Logout()
        {
            ManejoSesion.LogOut();
        }
    }
}
