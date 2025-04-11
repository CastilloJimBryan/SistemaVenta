using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Componente:Entity
    {
        public string Nombre { get; set; }
        public bool EsRol { get; set; }
        
        public abstract List<Componente> Componentes { get; }
        public abstract void AgregarComponente(Componente c);
        public abstract void QuitarComponente(Componente c);


    }
}
