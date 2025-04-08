using BE;
using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductoBL
    {
        ProductoDAL productoDAL;
        public ProductoBL()
        {
            productoDAL = new ProductoDAL();
        }
        public List<Producto> ListarProducto()
        {
            return productoDAL.ListadoProducto();
        }
        public void AgregarProducto(Producto p)
        {
             productoDAL.AgregarProducto(p);
        }
        public Producto VerProductoId(int mid)
        {
            return productoDAL.VerProductoId(mid);
        }
    }
}
