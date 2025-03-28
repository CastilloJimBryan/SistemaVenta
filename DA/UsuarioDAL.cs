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
    public class UsuarioDAL
    {
        SqlConnection connection => new SqlConnection(ConfigurationManager.ConnectionStrings["BDA"].ConnectionString);
        public Usuario ObtenerUserPass(string nom, string psw)
        {
            using (SqlConnection con=connection)
            {
                con.Open();
                using (SqlCommand cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType=CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Usuario WHERE Nombre=@Nombre AND Clave=@Clave";
                    cmd.Parameters.AddWithValue("@Nombre",nom);
                    cmd.Parameters.AddWithValue("@Clave",psw);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if(dr.Read())
                        {
                            return new Usuario
                            {
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                DNI = int.Parse(dr["dni"].ToString()),
                                Clave = dr["Clave"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = int.Parse(dr["Telefono"].ToString()),
                                Estado = bool.Parse(dr["Estado"].ToString())
                            };
                        }
                        return null;
                    }
                }
            }
        }
    }
}
