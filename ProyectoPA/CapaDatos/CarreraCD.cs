using ProyectoPA.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA.CapaDatos
{
    public class CarreraCD
    {
        public static List<ListarCarreraResult> ListarCarreraPA()
        {
            DataClasses1DataContext DB = null;
            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    return DB.ListarCarrera().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar en datos la carrera", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<ListarCarreraFiltrarResult> ListarCarreraFiltrar(string valor)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    return DB.ListarCarreraFiltrar(valor).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al listar en datos la carrera a filtrar", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarCarrera(Entidades.Carrera op)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    DB.InsertarCarrera(op.IdCarrera, op.IdBus, op.IdRuta, op.IdChofer, op.HoraEntrada, op.HoraSalida, op.Estado);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al insertar la carrera", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ActualizarCarrera(Entidades.Carrera op)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    DB.ActualizarCarrera(op.IdCarrera, op.IdBus, op.IdRuta, op.IdChofer, op.HoraEntrada, op.HoraSalida, op.Estado);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al actualizar la carrera", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
