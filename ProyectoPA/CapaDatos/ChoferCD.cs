using ProyectoPA.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA.CapaDatos
{
    public class ChoferCD
    {
        public static List<ListarChoferFiltrarResult> ListarChoferFiltrar(string valor)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    return DB.ListarChoferFiltrar(valor).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al listar en datos el Chofer a filtrar", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<ListarChoferResult> ListarChofer()
        {
            DataClasses1DataContext DB = null;
            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    return DB.ListarChofer().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar en datos del Chofer", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarChofer(Entidades.Chofer op)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    DB.InsertarChofer(op.IdChofer, op.Nombre, op.Apellidos, op.TipoLicencia, op.Cedula);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al insertar el Chofer", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ActualizarChofer(Entidades.Chofer op)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    DB.ActualizarChofer(op.IdChofer, op.Nombre, op.Apellidos, op.TipoLicencia, op.Cedula);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al actualizar el chofer", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarChofer(Entidades.Chofer op)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    DB.EliminarChofer(op.IdChofer, op.Nombre, op.Apellidos, op.TipoLicencia, op.Cedula);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al eliminar el chofer", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
