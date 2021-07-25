using ProyectoPA.BD;
using ProyectoPA.CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA.Logica
{
    public class BusLN
    {
        public List<Entidades.Buses> ViewBusFiltro(string valor)
        {
            List<Entidades.Buses> Lista = new List<Entidades.Buses>();
            Entidades.Buses op = null;
            try
            {
                List<ListarBusFiltrarResult> auxlista = BusesCD.ListarBusFiltrar(valor);
                foreach (ListarBusFiltrarResult olp in auxlista)
                {
                    op = new Entidades.Buses(olp.IDBus, olp.Placa, olp.Modelo, olp.Dueno, olp.NoBus);
                    Lista.Add(op);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar en la logica al orden detalle", ex);
            }
        }

        public List<Entidades.Buses> ViewBus()
        {
            List<Entidades.Buses> Lista = new List<Entidades.Buses>();
            Entidades.Buses op = null;
            try
            {
                List<ListarBusesResult> auxlista = BusesCD.ListarBus();
                foreach (ListarBusesResult olp in auxlista)
                {
                    op = new Entidades.Buses(olp.IDBus, olp.Placa, olp.Modelo, olp.Dueno, olp.NoBus);
                    Lista.Add(op);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar en la logica al los buses", ex);
            }

        }

        public bool CreateBuses(Entidades.Buses op)
        {
            try
            {
                BusesCD.InsertarBuses(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear a los buses", ex);
            }
        }

        public bool UpdateBuses(Entidades.Buses op)
        {
            try
            {
                BusesCD.ActualizarBuses(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al update a los buses", ex);
            }
        }

        public bool DeleteBuses(Entidades.Buses op)
        {
            try
            {
                BusesCD.EliminarBuses(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al delete a los buses", ex);
            }
        }


    }
}
