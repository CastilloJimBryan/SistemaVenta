using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class ManejoSesion
    {
        public Usuario usuario;
        private static ManejoSesion _getSesion;
        public static ManejoSesion GetSesion
        {
            get
            {
                return _getSesion;
            }
        }
        public static void LogIn(Usuario usuario)
        {
            if(_getSesion == null)
            {
                _getSesion = new ManejoSesion();
                _getSesion.usuario = usuario;
            }
            else
            {
                throw new Exception("Sesion ya Iniciada!!");
            }
        }

        public static void LogOut()
        {
            if(_getSesion != null)
            {
                _getSesion=null;
            }
            else
            {
                throw new Exception("Sesion No Iniciada!!");
            }
        }

        public static bool IsLoggin()
        {
            return _getSesion != null;
        }
    }
}
