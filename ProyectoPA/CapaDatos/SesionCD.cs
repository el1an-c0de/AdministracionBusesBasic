using ProyectoPA.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA.CapaDatos
{
    public class SesionCD
    {

        public static List<ListarSesionResult> ListarSesionPA()
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    return DB.ListarSesion().ToList();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al listar en datos la sesion", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void InsertarSesion(Entidades.Sesion op)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    DB.InsertarSesion(op.IdSesion,op.Usuario, op.Contrasena, op.Tipo);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al insertar el usuario", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ActualizarSesion(Entidades.Sesion op)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    DB.ActualizarSesion(op.IdSesion,op.Usuario, op.Contrasena, op.Tipo);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al actualizar el usuario", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarSesion(Entidades.Sesion op)
        {
            DataClasses1DataContext DB = null;

            try
            {
                using (DB = new DataClasses1DataContext())
                {
                    DB.EliminarSesion(op.IdSesion,op.Usuario, op.Contrasena, op.Tipo);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new DatosExcepciones("Error al eliminar el usuario", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
