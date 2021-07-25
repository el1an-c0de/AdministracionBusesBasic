using ProyectoPA.BD;
using ProyectoPA.CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA.Logica
{
    public class RutaLN
    {
        public List<Entidades.Ruta> ViewRutaFiltro(string valor)
        {
            List<Entidades.Ruta> Lista = new List<Entidades.Ruta>();
            Entidades.Ruta op = null;
            try
            {
                List<ListarRutaFiltrarResult> auxlista = RutaCD.ListarRutaFiltrar(valor);
                foreach (ListarRutaFiltrarResult olp in auxlista)
                {
                    op = new Entidades.Ruta(olp.IDRuta, olp.NombreRuta, Convert.ToDouble( olp.Tarifa));
                    Lista.Add(op);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar en la logica al orden detalle", ex);
            }
        }

        public List<Entidades.Ruta> ViewRuta()
        {
            List<Entidades.Ruta> Lista = new List<Entidades.Ruta>();
            Entidades.Ruta op = null;
            try
            {
                List<ListarRutaResult> auxlista = RutaCD.ListarRuta();
                foreach (ListarRutaResult olp in auxlista)
                {
                    op = new Entidades.Ruta(olp.IDRuta, olp.NombreRuta, Convert.ToDouble(olp.Tarifa));
                    Lista.Add(op);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostar en la logica al orden detalle", ex);
            }

        }

        public bool CreateRuta(Entidades.Ruta op)
        {
            try
            {
                RutaCD.InsertarRuta(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear la ruta", ex);
            }
        }

        public bool UpdateRuta(Entidades.Ruta op)
        {
            try
            {
                RutaCD.ActualizarRuta(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al update la ruta", ex);
            }
        }

        public bool DeleteRuta(Entidades.Ruta op)
        {
            try
            {
                RutaCD.EliminarRuta(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al delete la ruta", ex);
            }
        }
    }
}
