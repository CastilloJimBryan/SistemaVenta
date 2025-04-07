using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class CategoriaDAL
    {
        SqlConnection connection => new SqlConnection(ConfigurationManager.ConnectionStrings["BDA"].ConnectionString);
        
        public int AgregarCategoria(Categoria c)
        {
            using (SqlConnection con=connection)
            {
                con.Open();
                using (SqlCommand cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Categoria (Nombre) VALUES (@Nombre)";
                    cmd.Parameters.AddWithValue("@Nombre",c.Nombre);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public Categoria VerCategoria(int mid)
        {
            using (SqlConnection con=connection)
            {
                con.Open();
                using (SqlCommand cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType= CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Categoria WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", mid);
                    using (SqlDataReader dr=cmd.ExecuteReader())
                    {
                        if(dr.Read())
                        {
                            return new Categoria()
                            {
                                Id = int.Parse(dr["Id"].ToString()),
                                Nombre = dr["Nombre"].ToString()
                            };
                        }
                        return null;
                    }
                        
                }
            }
        }
        public List<Categoria> ListadoCategoria()
        {
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Categoria";

                    List<Categoria> list = new List<Categoria>();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(new Categoria()
                            {
                                Id = int.Parse(dr["Id"].ToString()),
                                Nombre = dr["Nombre"].ToString()
                            });
                        }
                        return list;
                    }

                }
            }
        }
        public int EditarCategoria(Categoria c)
        {
            using (SqlConnection con=connection)
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Categoria SET Nombre=@Nombre WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", c.Id);
                    cmd.Parameters.AddWithValue("@Nombre",c.Nombre);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public int EliminarCategoria(Categoria c)
        {
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Categoria WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id",c.Id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
