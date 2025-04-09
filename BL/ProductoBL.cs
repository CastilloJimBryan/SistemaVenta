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
        public int EditarProducto(Producto p)
        {
            return productoDAL.EditarProducto(p);
        }
        public int EliminarProducto(Producto p)
        {
            return productoDAL.EliminarProducto(p);
        }
        #region RelacionCateProd
        public int EditarRelacionProductoCategoria(Producto p)
        {
            return productoDAL.EditarRelacionProductoCategoria(p);
        }
        public int EliminarRelacionProductoCategoria(Producto p)
        {
            return productoDAL.EliminarRelacionProductoCategoria(p);
        }
        #endregion
    }
}
