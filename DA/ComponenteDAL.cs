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
    public class ComponenteDAL
    {
        SqlConnection connection => new SqlConnection(ConfigurationManager.ConnectionStrings["BDA"].ConnectionString);

        public int AgregarComponente (Componente c)
        {
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection= con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Rol (Nombre,EsRol) VALUES (@Nombre,@EsRol)";
                    cmd.Parameters.AddWithValue("@Nombre",c.Nombre);
                    cmd.Parameters.AddWithValue("@EsRol",c.EsRol);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Rol>ListarRol()
        {
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Rol WHERE EsRol=1";
                    List<Rol> list = new List<Rol>();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(new Rol
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

        public List<Accion> ListarAccion()
        {
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Rol WHERE EsRol=0";
                    List<Accion> list = new List<Accion>();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(new Accion
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
