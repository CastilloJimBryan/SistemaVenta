using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Producto:Entity
    {
		private int codigo;

		public int Codigo
		{
			get { return codigo; }
			set { codigo = value; }
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		private string descripcion;

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}
		private string categoria;

		public string Categoria
		{
			get { return categoria; }
			set { categoria = value; }
		}
		private float precioCompra;

		public float PrecioCompra
		{
			get { return precioCompra; }
			set { precioCompra = value; }
		}

		private float precioventa;

		public float PrecioVenta
		{
			get { return precioventa; }
			set { precioventa = value; }
		}
		private int cantidadMinima;

		public int CantidadMinima
		{
			get { return cantidadMinima; }
			set { cantidadMinima = value; }
		}
		private int cantidadMaxima;

		public int CantidadMaxima
		{
			get { return cantidadMaxima; }
			set { cantidadMaxima = value; }
		}


	}
}
