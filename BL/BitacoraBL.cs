using BE;
using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BitacoraBL
    {
        BitacoraDAL bitacoraDAL;
        public BitacoraBL()
        {
            bitacoraDAL = new BitacoraDAL();
        }
        public List<Bitacora> ListadoBitacora()
        {
            return bitacoraDAL.ListadoBitacora();
        }
        public int AgregarBitacora(Usuario u,string a)
        {
            return bitacoraDAL.AgregarBitacora(u,a);
        }
    }
}
