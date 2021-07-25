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
    public class SesionLN
    {
        public List<Entidades.Sesion> ViewSesion()
        {
            List<Entidades.Sesion> Lista = new List<Entidades.Sesion>();
            Entidades.Sesion op = null;
            try
            {
                List<ListarSesionResult> auxlista = SesionCD.ListarSesionPA();
                foreach (ListarSesionResult olp in auxlista)
                {
                    op = new Entidades.Sesion(olp.IDSesion,olp.Usuario, olp.Contrasena, olp.Tipo);
                    Lista.Add(op);
                }

                return Lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostrar en la logica la sesion", ex);
            }
        }
        public bool CreateSesion(Entidades.Sesion op)
        {
            try
            {
                SesionCD.InsertarSesion(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear la nueca sesion", ex);
            }
        }
        public bool UpdateSesion(Entidades.Sesion op)
        {
            try
            {
                SesionCD.ActualizarSesion(op);
                
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar la nueva sesion", ex);
            }
        }

        public bool DeleteSesion(Entidades.Sesion op)
        {
            try
            {
                SesionCD.EliminarSesion(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al delete la nueva sesiono", ex);
            }
        }
    }
}
