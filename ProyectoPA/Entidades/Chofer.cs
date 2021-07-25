using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA.Entidades
{
    public class Chofer
    {
        private int idChofer;
        private string nombre;
        private string apellidos;
        private string tipoLicencia;
        private string cedula;

        public Chofer()
        {
        }

        public Chofer(int idChofer, string nombre, string apellidos, string tipoLicencia, string cedula)
        {
            this.IdChofer = idChofer;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.TipoLicencia = tipoLicencia;
            this.Cedula = cedula;
        }

        public int IdChofer { get => idChofer; set => idChofer = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string TipoLicencia { get => tipoLicencia; set => tipoLicencia = value; }
        public string Cedula { get => cedula; set => cedula = value; }
    }
}
