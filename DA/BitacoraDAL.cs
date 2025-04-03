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
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT Bitacora.Id,Actividad,Fecha,Usuario.Id as UsuarioId,Usuario.Nombre as Usuario" +
                        " FROM Bitacora" +
                        " INNER JOIN Usuario ON Bitacora.UsuarioId=Usuario.Id";
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
                                Actividad = dr["Activida"].ToString(),
                                Fecha = DateTime.Parse(dr["Fecha"].ToString())
                            });
                        }
                        return list;
                    }
                }
            }
        }
    }
}
