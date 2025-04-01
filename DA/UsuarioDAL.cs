﻿using BE;
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
        public List<Usuario> ListadoEmpleados()
        {
            using (SqlConnection con=connection)
            {
                con.Open();
                using (SqlCommand cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType=CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Usuario";
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
                                Clave = dr["Clave"].ToString (),
                                Estado = bool.Parse(dr["Estado"].ToString())
                            });
                        }
                        return list;
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
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Usuario (Nombre,Apellido,DNI,Clave,Correo,Telefono,Estado) VALUES (@Nombre,@Apellido,@DNI,@Clave,@Correo,@Telefono,@Estado);";
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

        #endregion
    }
}
