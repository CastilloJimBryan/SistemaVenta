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
        public LoginBL()
        {
            usuarioDAL = new UsuarioDAL();
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
        }
        public void Logout()
        {
            ManejoSesion.LogOut();
        }
    }
}
