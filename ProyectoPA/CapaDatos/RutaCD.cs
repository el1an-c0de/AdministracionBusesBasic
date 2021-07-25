using ProyectoPA.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA.CapaDatos
{
    public class RutaCD
    {
        public static List<ListarRutaFiltrarResult> ListarRutaFiltrar(string valor)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    return DB.ListarRutaFiltrar(valor).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al listar en datos la ruta filtrar", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<ListarRutaResult> ListarRuta()
        {
            DataClasses1DataContext DB = null;
            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    return DB.ListarRuta().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar en datos la ruta", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarRuta(Entidades.Ruta op)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    DB.InsertarRuta(op.IdRuta, op.Nombre, Convert.ToDecimal( op.Tarifa));
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al insertar la ruta", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ActualizarRuta(Entidades.Ruta op)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    DB.ActualizarRuta(op.IdRuta, op.Nombre, Convert.ToDecimal(op.Tarifa));
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al actualizar la ruta", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarRuta(Entidades.Ruta op)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    DB.EliminarRuta(op.IdRuta, op.Nombre, Convert.ToDecimal(op.Tarifa));
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al eliminar la ruta", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
