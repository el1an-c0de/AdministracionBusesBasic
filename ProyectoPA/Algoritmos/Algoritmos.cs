using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPA.Algoritmos
{
    public class Algoritmos
    {
        public static void addFormulario(Panel panel, Form form)
        {
            if (panel.Controls.Count > 0) //Verifica si hay formularios dentro del panel
                panel.Controls.RemoveAt(0); //Remueve todos los formularios del panel antes de agregar otro
            form.TopLevel = false;
            panel.Controls.Add(form);
            form.Show();
        }
    }
}
