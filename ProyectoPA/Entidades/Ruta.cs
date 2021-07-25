using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA.Entidades
{
    public class Ruta
    {
        private int idRuta;
        private string nombre;
        private double tarifa;

        public Ruta()
        {
        }

        public Ruta(int idRuta, string nombre, double tarifa)
        {
            this.IdRuta = idRuta;
            this.Nombre = nombre;
            this.Tarifa = tarifa;
        }

        public int IdRuta { get => idRuta; set => idRuta = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Tarifa { get => tarifa; set => tarifa = value; }
    }
}
