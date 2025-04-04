using BE;
using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CategoriaBL
    {
        CategoriaDAL CategoriaDAL;

        public CategoriaBL()
        {
            CategoriaDAL = new CategoriaDAL(); 
        }

        public int AgregarCategoria(Categoria c)
        {
            return CategoriaDAL.AgregarCategoria(c);
        }
        public List<Categoria> ListadoCategoria()
        {
            return CategoriaDAL.ListadoCategoria();
        }
    }
}
