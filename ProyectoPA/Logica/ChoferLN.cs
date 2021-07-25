using ProyectoPA.BD;
using ProyectoPA.CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA.Logica
{
    public class ChoferLN
    {
        public List<Entidades.Chofer> ViewChoferFiltro(string valor)
        {
            List<Entidades.Chofer> Lista = new List<Entidades.Chofer>();
            Entidades.Chofer op = null;
            try
            {
                List<ListarChoferFiltrarResult> auxlista = ChoferCD.ListarChoferFiltrar(valor);
                foreach (ListarChoferFiltrarResult olp in auxlista)
                {
                    op = new Entidades.Chofer(olp.IDChofer, olp.Nombres, olp.Apellidos, olp.TipoLicencia, olp.Cedula);
                    Lista.Add(op);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar en la logica al chofer", ex);
            }
        }

        public List<Entidades.Chofer> ViewChofer()
        {
            List<Entidades.Chofer> Lista = new List<Entidades.Chofer>();
            Entidades.Chofer op = null;
            try
            {
                List<ListarChoferResult> auxlista = ChoferCD.ListarChofer();
                foreach (ListarChoferResult olp in auxlista)
                {
                    op = new Entidades.Chofer(olp.IDChofer, olp.Nombres, olp.Apellidos, olp.TipoLicencia, olp.Cedula);
                    Lista.Add(op);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar en la logica al chofer", ex);
            }

        }

        public bool CreateChofer(Entidades.Chofer op)
        {
            try
            {
                ChoferCD.InsertarChofer(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear el Chofer", ex);
            }
        }

        public bool UpdateChofer(Entidades.Chofer op)
        {
            try
            {
                ChoferCD.ActualizarChofer(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar el Chofer", ex);
            }
        }

        public bool DeleteChofer(Entidades.Chofer op)
        {
            try
            {
                ChoferCD.EliminarChofer(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar el chofer", ex);
            }
        }
    }
}
