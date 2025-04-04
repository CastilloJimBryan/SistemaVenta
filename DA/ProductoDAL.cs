using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class ProductoDAL
    {
        SqlConnection connection => new SqlConnection(ConfigurationManager.ConnectionStrings["BDA"].ConnectionString);

        public List<Producto> ListadoProducto()
        {
            using (SqlConnection con=connection)
            {
                con.Open();
                using (SqlCommand cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType =CommandType.Text;
                    cmd.CommandText = "SELECT producto.id,codigo,producto.nombre,descripcion,categoria.Nombre as Categoria,preciocompra,precioventa,cantidadminima,cantidadmaxima " +
                        " FROM Producto " +
                        " INNER JOIN Categoria on producto.categoriaId=categoria.id";

                    List<Producto> list= new List<Producto>();
                    using (SqlDataReader dr=cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Producto p = new Producto()
                            {
                                Id = int.Parse(dr["Id"].ToString()),
                                Codigo = int.Parse(dr["Codigo"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                PrecioCompra = int.Parse(dr["PrecioCompra"].ToString()),
                                PrecioVenta = int.Parse(dr["PrecioVenta"].ToString()),
                                CantidadMinima = int.Parse(dr["CantidadMinima"].ToString()),
                                CantidadMaxima = int.Parse(dr["CantidadMaxima"].ToString()),
                            };
                            list.Add(p);
                        }
                        return list;
                    }
                       
                }
            }
        }
    }
}
