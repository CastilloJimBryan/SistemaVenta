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
    public class BitacoraDAL
    {
        SqlConnection connection => new SqlConnection(ConfigurationManager.ConnectionStrings["BDA"].ConnectionString);
        public List<Bitacora> ListadoBitacora()
        {
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection= con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ListadoBitacora";
                    List<Bitacora> list=new List<Bitacora>();
                    using (SqlDataReader dr=cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            list.Add(new Bitacora
                            {
                                Id = int.Parse(dr["Id"].ToString()),
                                UsuarioId = int.Parse(dr["UsuarioId"].ToString()),
                                Usuario = dr["Usuario"].ToString(),
                                Actividad = dr["Actividad"].ToString(),
                                Fecha = DateTime.Parse(dr["Fecha"].ToString())
                            });
                        }
                        return list;
                    }
                }
            }
        }

        public int AgregarBitacora(Usuario u,string actividad)
        {
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AgregarBitacora";
                    cmd.Parameters.AddWithValue("@UsuarioId",u.Id);
                    cmd.Parameters.AddWithValue("@Actividad",actividad);
                    cmd.Parameters.AddWithValue("@Fecha",DateTime.Now);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
