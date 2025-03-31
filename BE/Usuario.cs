using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario:Entity
    {
		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		private string apellido;

		public string Apellido
		{
			get { return apellido; }
			set { apellido = value; }
		}
		private int dni;

		public int DNI
		{
			get { return dni; }
			set { dni = value; }
		}

		private string clave;

		public string Clave
		{
			get { return clave; }
			set { clave = value; }
		}
		private string correo;

		public string Correo
		{
			get { return correo; }
			set { correo = value; }
		}
		private bool estado;

		public bool Estado
		{
			get { return estado; }
			set { estado = value; }
		}
		private int telefono;

		public int Telefono
		{
			get { return telefono; }
			set { telefono = value; }
		}
	}
}
