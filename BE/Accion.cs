using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Accion : Componente
    {
        public Accion()
        {
            EsRol = false;
        }
        public override List<Componente> Componentes
        {
            get
            {
                return new List<Componente>();
            }
        }

        public override void AgregarComponente(Componente c)
        {
        }

        public override void QuitarComponente(Componente c)
        {
        }

        public override void VaciarAccion()
        {
          
        }
    }
}
