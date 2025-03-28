using DA;
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
        public void ObtenerUserPass(string nom,string psw)
        {
            usuarioDAL.ObtenerUserPass(nom, psw);
        }
    }
}
