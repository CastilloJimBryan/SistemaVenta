﻿using BE;
using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UsuarioBL
    {
        UsuarioDAL usuarioDAL;
        public UsuarioBL()
        {
            usuarioDAL = new UsuarioDAL();
        }
        #region DatosUsuario

        public List<Usuario> ListarEmpleados()
        {
            return usuarioDAL.ListadoEmpleados();
        }
        public int AgregarUsuario(Usuario u)
        {
            return usuarioDAL.AgregarUsuario(u);
        }
        public Usuario VerUsuarioId(int mid)
        {
            return usuarioDAL.VerUsuarioId(mid);
        }
        public int EditarUsuario(Usuario u)
        {
            return usuarioDAL.EditarUsuario(u);
        }
        public int EliminarUsuario(Usuario u)
        {
            return usuarioDAL.EliminarUsuario(u);
        }
        #endregion

        #region HistorialUsuario
        public List<HistorialUsuario>ListarHistorial(int mid)
        {
            return usuarioDAL.ListarHistorial(mid);
        }
        public int AgregarAHistorial(Usuario u)
        {
            return usuarioDAL.AgregarAHistorial(u);
        }
        public HistorialUsuario VerHistorialUsuarioId(int mid)
        {
            return usuarioDAL.VerHistorialUsuarioId(mid);
        }
        public void RestaurarUsuario(HistorialUsuario hu)
        {
            usuarioDAL.RestaurarUsuario(hu);
        }

        public void EliminarDelHistorial(HistorialUsuario hu)
        {
            usuarioDAL.EliminarDelHistorial(hu);
        }
        #endregion

        public void InsertarRelacionUserRol(Usuario u)
        {
            usuarioDAL.AgregarRelacionUserRol(u);
        }
    }
}
