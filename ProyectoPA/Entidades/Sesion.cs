using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPA.Entidades
{
    public class Sesion
    {
        private int idSesion;
        private string usuario;
        private string contrasena;
        private string tipo;

        public Sesion()
        {
        }

        public Sesion(int idSesion, string usuario, string contrasena, string tipo)
        {
            this.IdSesion = idSesion;
            this.Usuario = usuario;
            this.Contrasena = contrasena;
            this.Tipo = tipo;
        }

        public int IdSesion { get => idSesion; set => idSesion = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}
