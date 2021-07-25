using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA.Entidades
{
    public class Carrera
    {
        private int idCarrera;
        private DateTime horaSalida;
        private DateTime horaEntrada;
        private string estado;
        private int idBus;
        private int idRuta;
        private int idChofer;

        public Carrera()
        {
        }

        public Carrera(int idCarrera, DateTime horaSalida, DateTime horaEntrada, string estado, int idBus, int idRuta, int idChofer)
        {
            this.IdCarrera = idCarrera;
            this.HoraSalida = horaSalida;
            this.HoraEntrada = horaEntrada;
            this.Estado = estado;
            this.IdBus = idBus;
            this.IdRuta = idRuta;
            this.IdChofer = idChofer;
        }

        public int IdCarrera { get => idCarrera; set => idCarrera = value; }
        public DateTime HoraSalida { get => horaSalida; set => horaSalida = value; }
        public DateTime HoraEntrada { get => horaEntrada; set => horaEntrada = value; }
        public string Estado { get => estado; set => estado = value; }
        public int IdBus { get => idBus; set => idBus = value; }
        public int IdRuta { get => idRuta; set => idRuta = value; }
        public int IdChofer { get => idChofer; set => idChofer = value; }
    }
}
