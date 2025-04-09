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
                    cmd.CommandType =CommandType.StoredProcedure;
                    cmd.CommandText = "ListarProducto";
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

        public void AgregarProducto(Producto p)
        {
            using (SqlConnection con=connection)
            {
                con.Open();
                using (SqlCommand cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AgregarProducto";
                    cmd.Parameters.AddWithValue("@Codigo",p.Codigo);
                    cmd.Parameters.AddWithValue("@Nombre",p.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion",p.Descripcion);
                    cmd.Parameters.AddWithValue("@CategoriaId",p.Categoria);
                    cmd.Parameters.AddWithValue("@PrecioCompra",p.PrecioCompra);
                    cmd.Parameters.AddWithValue("@PrecioVenta",p.PrecioVenta);
                    cmd.Parameters.AddWithValue("@CantidadMinima",p.CantidadMinima);
                    cmd.Parameters.AddWithValue("@CantidadMaxima",p.CantidadMaxima);

                    int mid=Convert.ToInt32(cmd.ExecuteScalar());

                    foreach (Categoria item in p.Categorias)
                    {
                        using (SqlCommand cmds=new SqlCommand())
                        {
                            cmds.Connection = con;
                            cmds.CommandType = CommandType.StoredProcedure;
                            cmds.CommandText = "AgregarRelacionProductoCategoria";
                            cmds.Parameters.AddWithValue("@ProductoId",mid);
                            cmds.Parameters.AddWithValue("@CategoriaId",item.Id);
                            cmds.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public Producto VerProductoId(int mid)
        {
            using (SqlConnection con=connection)
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT Producto.Id,Codigo,producto.nombre,Descripcion,Categoria.Nombre as Categoria,PrecioCompra,PrecioVenta,CantidadMinima,CantidadMaxima " +
                        " FROM Producto " +
                        " INNER JOIN Categoria on Producto.CategoriaId=Categoria.Id " +
                        " WHERE Producto.Id=@Id ";
                    cmd.Parameters.AddWithValue("@Id", mid);
                    using (SqlDataReader dr=cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new Producto()
                            {
                                Id=int.Parse(dr["Id"].ToString()),
                                Codigo=int.Parse(dr["Codigo"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Categoria=dr["Categoria"].ToString(),
                                PrecioCompra = int.Parse(dr["PrecioCompra"].ToString()),
                                PrecioVenta = int.Parse(dr["PrecioVenta"].ToString()),
                                CantidadMinima = int.Parse(dr["CantidadMinima"].ToString()),
                                CantidadMaxima = int.Parse(dr["CantidadMaxima"].ToString()),
                            };
                        }
                        return null;
                    }
                }
            }
        }
        #region RelacionConCategoria
        public int EditarRelacionProductoCategoria(Producto p)
        {
            using (SqlConnection con=connection)
            {
                con.Open();
                using (SqlCommand cmds = new SqlCommand())
                {
                    cmds.Connection = con;
                    cmds.CommandType = CommandType.Text;
                    cmds.CommandText = "UPDATE Producto_Categoria SET ProductoId=@ProductoId,CategoriaId=@CategoriaId " +
                        " WHERE productoId=@productoId ";
                    cmds.Parameters.AddWithValue("@ProductoId", p.Id);
                    cmds.Parameters.AddWithValue("@CategoriaId", p.Categoria);
                    return cmds.ExecuteNonQuery();
                }
            }
        }
        public int EliminarRelacionProductoCategoria(Producto p)
        {
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmds = new SqlCommand())
                {
                    cmds.Connection = con;
                    cmds.CommandType = CommandType.Text;
                    cmds.CommandText = "DELETE Producto_Categoria WHERE ProductoId=@ProductoId";
                    cmds.Parameters.AddWithValue("@ProductoId", p.Id);
                    //cmds.Parameters.AddWithValue("@CategoriaId", p.Categoria);
                    return cmds.ExecuteNonQuery();
                }
            }
        }
        #endregion
        public int EditarProducto(Producto p)
        {
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " UPDATE Producto " +
                        " SET Codigo=@Codigo,Nombre=@Nombre,Descripcion=@Descripcion,CategoriaId=@CategoriaId,PrecioCompra=@PrecioCompra,PrecioVenta=@PrecioVenta,CantidadMinima=@CantidadMinima,CantidadMaxima=@CantidadMaxima " +
                        " WHERE Id=@Id ";
                    cmd.Parameters.AddWithValue("@Id",p.Id);
                    cmd.Parameters.AddWithValue("@Codigo",p.Codigo);
                    cmd.Parameters.AddWithValue("@Nombre",p.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion",p.Descripcion);
                    cmd.Parameters.AddWithValue("@CategoriaId",p.Categoria);
                    cmd.Parameters.AddWithValue("@PrecioCompra",p.PrecioCompra);
                    cmd.Parameters.AddWithValue("@PrecioVenta",p.PrecioVenta);
                    cmd.Parameters.AddWithValue("@CantidadMinima",p.CantidadMinima);
                    cmd.Parameters.AddWithValue("@CantidadMaxima",p.CantidadMaxima);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public int EliminarProducto(Producto p)
        {
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText ="DELETE Producto WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", p.Id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
