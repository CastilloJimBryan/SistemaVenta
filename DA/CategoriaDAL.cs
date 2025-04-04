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
    }
}
