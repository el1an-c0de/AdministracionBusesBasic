using ProyectoPA.BD;
using ProyectoPA.CapaDatos;
using ProyectoPA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA.Logica
{
    public class CarreraLN
    {
        public List<Entidades.Carrera> ViewCarrera()
        {
            List<Entidades.Carrera> Lista = new List<Entidades.Carrera>();
            Entidades.Carrera op = null;
            try
            {
                List<ListarCarreraResult> auxlista = CarreraCD.ListarCarreraPA();
                foreach (ListarCarreraResult olp in auxlista)
                {
                    op = new Entidades.Carrera(olp.IDCarrera, olp.Tiempo, olp.HoraLlegada, olp.Estado, Convert.ToInt32(olp.IDBus), Convert.ToInt32(olp.IDRuta), Convert.ToInt32(olp.IDChofer));
                    Lista.Add(op);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar en la logica de la carrera", ex);
            }
        }

        public List<Entidades.Carrera> ViewCarreraFiltro(string valor)
        {
            List<Entidades.Carrera> Lista = new List<Entidades.Carrera>();
            Entidades.Carrera op = null;
            try
            {
                List<ListarCarreraFiltrarResult> auxlista = CarreraCD.ListarCarreraFiltrar(valor);
                foreach (ListarCarreraFiltrarResult olp in auxlista)
                {
                    op = new Entidades.Carrera(olp.IDCarrera, olp.Tiempo, olp.HoraLlegada, olp.Estado, Convert.ToInt32(olp.IDBus), Convert.ToInt32(olp.IDRuta), Convert.ToInt32(olp.IDChofer));
                    Lista.Add(op);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar en la logica de la carrera", ex);
            }
        }

        public bool CreateCarrera(Entidades.Carrera op)
        {
            try
            {
                CarreraCD.InsertarCarrera(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear la carrera", ex);
            }
        }

        public bool UpdateCarrera(Entidades.Carrera op)
        {
            try
            {
                CarreraCD.ActualizarCarrera(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al update la carrera", ex);
            }
        }
    }
}
