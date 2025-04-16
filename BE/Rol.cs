using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Rol : Componente
    {
        List<Componente> _componentes;
        public Rol()
        {
            EsRol = true;
            _componentes = new List<Componente>();
        }
        public override List<Componente> Componentes
        {
            get {  return _componentes; }
        }

        public override void AgregarComponente(Componente c)
        {
            _componentes.Add(c);
        }

        public override void QuitarComponente(Componente c)
        {
            _componentes.Remove(c);
        }

        public override void VaciarAccion()
        {
           _componentes=new List<Componente>();
        }
    }
}
