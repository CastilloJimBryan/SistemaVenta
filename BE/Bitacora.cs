using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bitacora:Entity
    {
		private DateTime fecha;

		public DateTime Fecha
		{
			get { return fecha; }
			set { fecha = value; }
		}
		private string usuario;

		public string Usuario
		{
			get { return usuario; }
			set { usuario = value; }
		}
		private int usuarioId;

		public int UsuarioId
		{
			get { return usuarioId; }
			set { usuarioId = value; }
		}

		private string actividad;

		public string Actividad
		{
			get { return actividad; }
			set { actividad = value; }
		}


	}
}
