using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
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
        public List<Componente>ListarTodo(string text)
        {
            string where = "Is NULL";
            if (string.IsNullOrEmpty(text))
            {
                where = text;
            }
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmd=new SqlCommand())
                {
                    cmd.Connection= con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"WITH recursivo as (SELECT PadreId,HijoId FROM Rol_Rol " +
                        $" WHERE PadreId {where} " +
                        $" UNION ALL " +
                        $" SELECT Rol_Rol.PadreId,Rol_Rol.HijoId FROM Rol_Rol " +
                        $" INNER JOIN recursivo ON Rol_Rol.PadreId=recursivo.HijoId ) " +
                        $" SELECT recursivo.PadreId,recursivo.HijoId,Rol.Id,Rol.Nombre,Rol.EsRol FROM recursivo " +
                        $" INNER JOIN Rol ON recursivo.HijoId=Rol.Id ";

                    List<Componente> lis= new List<Componente>();
                    using (SqlDataReader dr=cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int IdPadre = 0;
                            if (dr["PadreId"] != DBNull.Value)
                            {
                                IdPadre = dr.GetInt32(dr.GetOrdinal("PadreId"));
                            }
                            int mid = dr.GetInt32(dr.GetOrdinal("Id"));
                            string nombre = dr.GetString(dr.GetOrdinal("Nombre"));
                            bool esrol = dr.GetBoolean(dr.GetOrdinal("EsRol"));

                            Componente c;
                            if (esrol)
                            {
                                c = new Rol();
                            }
                            else
                            {
                                c = new Accion();
                            }
                            c.Id = mid;
                            c.Nombre = nombre;
                            var p=Roles(IdPadre,lis);
                            if (p == null)
                            {
                                lis.Add(c);
                            }
                            else
                            {
                                p.AgregarComponente(c); 
                            }
                        }
                        return lis;
                    }

                }
            }
        }
        private Componente Roles(int id,List<Componente> list)
        {
            Componente c=list != null ? list.Where(i=>i.Id.Equals(id)).FirstOrDefault() : null;
            if(c == null && list!=null)
            {
                foreach(var item in list)
                {
                    var l = Roles(id, item.Componentes);
                    if(l!=null && l.Id == id)
                    {
                        return l;
                    }
                    else
                    {
                        if(l != null)
                        {
                            return Roles(id, l.Componentes);
                        }
                    }
                }
            }
            return c;
        }
        public void FillRol(Rol r)
        {
            r.VaciarAccion();
            foreach (var item in ListarTodo("=" + r.Id))
            {
                r.AgregarComponente(item);
            }
        }
        public void ObtenerRolesUsuario(Usuario u)
        {
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT Rol.Id,Rol.Nombre,Rol.EsRol " +
                        " FROM Usuario_Rol " +
                        " INNER JOIN Rol ON Usuario_Rol.RolId=Rol.Id " +
                        " WHERE Usuario_Rol.UsuarioId=@UsuarioId ";
                    cmd.Parameters.AddWithValue("@UsuarioId",u.Id);
                    using (SqlDataReader dr=cmd.ExecuteReader())
                    {
                        u.ComponenteList.Clear();
                        Componente c;
                        while (dr.Read())
                        {
                            int mid = dr.GetInt32(dr.GetOrdinal("Id"));
                            string nombre = dr.GetString(dr.GetOrdinal("Nombre"));
                            bool esrol = dr.GetBoolean(dr.GetOrdinal("EsRol"));
                            if (!esrol)
                            {
                                c = new Accion()
                                {
                                    Id = mid,
                                    Nombre = nombre,
                                };
                                u.ComponenteList.Add(c);
                            }
                            else
                            {
                                c = new Rol()
                                {
                                    Id = mid,
                                    Nombre = nombre,
                                };
                                var Lista = ListarTodo("=" + mid);
                                foreach (var item in Lista)
                                {
                                    c.AgregarComponente(item);
                                }
                                u.ComponenteList.Add(c);
                            }
                        }
                    }
                }
            }
        }
    }
}
