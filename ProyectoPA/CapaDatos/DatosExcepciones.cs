using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA.CapaDatos
{
    public class DatosExcepciones : ApplicationException
    {
        public DatosExcepciones(String mesaje, Exception original)
            : base(mesaje, original)
        {

        }
        public DatosExcepciones(String mesaje)
            : base(mesaje)
        {

        }
    }
}
