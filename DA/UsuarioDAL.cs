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
        #region FuncionesEmpleados

        public Usuario ObtenerUserPass(string nom, string psw)
        {
            using (SqlConnection con=connection)
            {
                con.Open();
                using (SqlCommand cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.CommandText = "ObtenerUserPass";
                    cmd.Parameters.AddWithValue("@Nombre",nom);
                    cmd.Parameters.AddWithValue("@Clave",psw);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if(dr.Read())
                        {
                            return new Usuario
                            {
                                Id= int.Parse(dr["Id"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                DNI = int.Parse(dr["DNI"].ToString()),
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
        public List<Usuario> ListadoEmpleados()
        {
            using (SqlConnection con=connection)
            {
                con.Open();
                using (SqlCommand cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.CommandText = "ListadoEmpleado";
                    List<Usuario> list=new List<Usuario>();
                    using (SqlDataReader dr=cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            list.Add(new Usuario
                            {
                                Id = int.Parse(dr["id"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                DNI = int.Parse(dr["DNI"].ToString() ),
                                Telefono = int.Parse(dr["Telefono"].ToString()),
                                Correo = dr["Correo"].ToString (),
                                Estado = bool.Parse(dr["Estado"].ToString())
                            });
                        }
                        return list;
                    }
                }
            }
        }
        public Usuario VerUsuarioId(int mid)
        {
            using (SqlConnection con=connection)
            {
                con.Open();
                using (SqlCommand cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.CommandText = "BuscarUsuarioXId";
                    cmd.Parameters.AddWithValue("@Id", mid);
                    using (SqlDataReader dr=cmd.ExecuteReader())
                    {
                        if(dr.Read())
                        {
                            return new Usuario
                            {
                                Id = int.Parse(dr["id"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                DNI = int.Parse(dr["DNI"].ToString()),
                                Telefono = int.Parse(dr["Telefono"].ToString()),
                                Estado = bool.Parse(dr["Estado"].ToString())
                            };
                        }
                        return null;
                    }
                }
            }
        }
        public int AgregarUsuario(Usuario u)
        {
            using (SqlConnection con=connection)
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AgregarUsuario";
                    cmd.Parameters.AddWithValue("@Nombre",u.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido",u.Apellido);
                    cmd.Parameters.AddWithValue("@DNI",u.DNI);
                    cmd.Parameters.AddWithValue("@Clave",u.Clave);
                    cmd.Parameters.AddWithValue("@Correo",u.Correo);
                    cmd.Parameters.AddWithValue("@Telefono",u.Telefono);
                    cmd.Parameters.AddWithValue("@Estado",u.Estado);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public int EditarUsuario(Usuario u)
        {
            using (SqlConnection con=connection)
            {
                con.Open();
                using (SqlCommand cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "EditarUsuario";
                    cmd.Parameters.AddWithValue("@Id",u.Id);
                    cmd.Parameters.AddWithValue("@Nombre",u.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido",u.Apellido);
                    cmd.Parameters.AddWithValue("@DNI",u.DNI);
                    cmd.Parameters.AddWithValue("@Clave",u.Clave);
                    cmd.Parameters.AddWithValue("@Correo",u.Correo);
                    cmd.Parameters.AddWithValue("@Telefono",u.Telefono);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public int EliminarUsuario(Usuario u)
        {
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "EliminarUsuario";
                    cmd.Parameters.AddWithValue("@Id", u.Id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region HistorialUsuario

        public List<HistorialUsuario> ListarHistorial(int mid)
        {
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM HistorialUsuario WHERE IdOriginal=@IdOriginal";
                    cmd.Parameters.AddWithValue("@IdOriginal",mid);
                    List<HistorialUsuario> list = new List<HistorialUsuario>();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(new HistorialUsuario
                            {
                                Id = int.Parse(dr["id"].ToString()),
                                IdOriginal = int.Parse(dr["idOriginal"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                DNI = int.Parse(dr["DNI"].ToString()),
                                Telefono = int.Parse(dr["Telefono"].ToString()),
                                Correo = dr["Correo"].ToString(),
                                Estado = bool.Parse(dr["Estado"].ToString()),
                                Fecha = DateTime.Parse(dr["Fecha"].ToString())
                            });
                        }
                        return list;
                    }
                }
            }
        }
        public HistorialUsuario VerHistorialUsuarioId(int mid)
        {
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM HistorialUsuario WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", mid);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new HistorialUsuario
                            {
                                Id = int.Parse(dr["Id"].ToString()),
                                IdOriginal= int.Parse(dr["IdOriginal"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                DNI = int.Parse(dr["DNI"].ToString()),
                                Telefono = int.Parse(dr["Telefono"].ToString()),
                                Estado = bool.Parse(dr["Estado"].ToString())
                            };
                        }
                        return null;
                    }
                }
            }
        }
        public int AgregarAHistorial(Usuario u)
        {
            using (SqlConnection con=connection)
            {
                con.Open();
                using (SqlCommand cmd=new  SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO HistorialUsuario (IdOriginal,Nombre,Apellido,DNI,Telefono,Correo,Estado,Fecha) " +
                        " VALUES (@IdOriginal,@Nombre,@Apellido,@DNI,@Telefono,@Correo,@Estado,@Fecha) ";
                    cmd.Parameters.AddWithValue("@IdOriginal",u.Id);
                    cmd.Parameters.AddWithValue("@Nombre",u.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido",u.Apellido);
                    cmd.Parameters.AddWithValue("@DNI",u.DNI);
                    cmd.Parameters.AddWithValue("@Telefono",u.Telefono);
                    cmd.Parameters.AddWithValue("@Correo",u.Correo);
                    cmd.Parameters.AddWithValue("@Estado",u.Estado);
                    cmd.Parameters.AddWithValue("@Fecha",DateTime.Now);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public void RestaurarUsuario(HistorialUsuario hu)
        {
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Usuario SET Nombre=@Nombre,Apellido=@Apellido,DNI=@DNI,Telefono=@Telefono,Correo=@Correo,Estado=@Estado " +
                        " WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", hu.IdOriginal);
                    cmd.Parameters.AddWithValue("@Nombre", hu.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", hu.Apellido);
                    cmd.Parameters.AddWithValue("@DNI", hu.DNI);
                    cmd.Parameters.AddWithValue("@Telefono", hu.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", hu.Correo);
                    cmd.Parameters.AddWithValue("@Estado", hu.Estado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarDelHistorial(HistorialUsuario hu)
        {
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE HistorialUsuario WHERE IdOriginal =@Id";
                    cmd.Parameters.AddWithValue("@Id", hu.IdOriginal);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        #endregion

        #region RelacionRol

        public void AgregarRelacionUserRol(Usuario u)
        {
            using (SqlConnection con = connection)
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $@"DELETE Usuario_Rol WHERE Usuario_Rol.UsuarioId=@UsuarioId";
                    cmd.Parameters.AddWithValue("@UsuarioId",u.Id);
                    foreach (var item in u.ComponenteList)
                    {
                        using (SqlCommand cmds=new SqlCommand())
                        {
                            cmds.Connection = con;
                            cmds.CommandType = CommandType.Text;
                            cmds.CommandText = "INSERT INTO Usuario_Rol (UsuarioId,RolId) VALUES (@UsuarioId,@RolId)";
                            cmds.Parameters.AddWithValue("@UsuarioId",u.Id);
                            cmds.Parameters.AddWithValue("@RolId",item.Id);
                            cmds.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        #endregion
    }
}
