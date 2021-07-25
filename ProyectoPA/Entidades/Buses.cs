using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA.Entidades
{
    public class Buses
    {
        private int idBus;
        private string placa;
        private string modelo;
        private string dueno;
        private int noBus;

        public Buses()
        {
        }

        public Buses(int idBus, string placa, string modelo, string dueno, int noBus)
        {
            this.IdBus = idBus;
            this.Placa = placa;
            this.Modelo = modelo;
            this.Dueno = dueno;
            this.NoBus = noBus;
        }

        public int IdBus { get => idBus; set => idBus = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Dueno { get => dueno; set => dueno = value; }
        public int NoBus { get => noBus; set => noBus = value; }
    }
}
