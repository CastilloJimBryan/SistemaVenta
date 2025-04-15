using BE;
using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ComponenteBL
    {
        ComponenteDAL componenteDAL;
        public ComponenteBL()
        {
            componenteDAL = new ComponenteDAL();
        }
        public int AgregarComponente(Componente c)
        {
            return componenteDAL.AgregarComponente(c);
        }
        public bool ExisteRol(Componente c,int mid)
        {
            bool existe=false;
            if(c.Id.Equals(mid))
            {
                existe= true;
            }
            else 
            {
                foreach (var item in c.Componentes)
                {
                    existe=ExisteRol(item, mid);
                    if(existe) return true;
                }
            }
            return existe;
        }
        public List<Rol> ListadoRol()
        {
            return componenteDAL.ListarRol();
        }
        public List<Accion> ListadoAccion()
        {
            return componenteDAL.ListarAccion();
        }
        public void ObtenerRolesUsuario(Usuario u)
        {
            componenteDAL.ObtenerRolesUsuario(u);
        }
    }
}
