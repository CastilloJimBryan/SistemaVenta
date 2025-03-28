using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		private int apellido;

		public int Apellido
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

		private int clave;

		public int Clave
		{
			get { return clave; }
			set { clave = value; }
		}
		private int correo;

		public int Correo
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
