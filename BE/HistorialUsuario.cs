using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HistorialUsuario:Usuario
    {
		private int idOriginal;

		public int IdOriginal
		{
			get { return idOriginal; }
			set { idOriginal = value; }
		}

		private DateTime fecha;

		public DateTime Fecha
		{
			get { return fecha; }
			set { fecha = value; }
		}

	}
}
