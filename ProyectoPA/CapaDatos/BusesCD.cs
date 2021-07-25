using ProyectoPA.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA.CapaDatos
{
    public class BusesCD
    {
        public static List<ListarBusFiltrarResult> ListarBusFiltrar(string valor)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    return DB.ListarBusFiltrar(valor).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al listar en datos el bus filtrar", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<ListarBusesResult> ListarBus()
        {
            DataClasses1DataContext DB = null;
            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    return DB.ListarBuses().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar en datos el bus", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarBuses(Entidades.Buses op)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    DB.InsertarBuses(op.IdBus, op.Placa, op.Modelo, op.Dueno, op.NoBus);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al insertar el bus", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ActualizarBuses(Entidades.Buses op)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    DB.ActualizarBuses(op.IdBus, op.Placa, op.Modelo, op.Dueno, op.NoBus);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al actualizar el bus", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarBuses(Entidades.Buses op)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    DB.EliminarBuses(op.IdBus, op.Placa, op.Modelo, op.Dueno, op.NoBus);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al eliminar el bus", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
