using ProyectoPA.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPA.Formularios
{
    public partial class frmChofer : Form
    {
        CarreraLN oodln = new CarreraLN();
        public frmChofer()
        {
            InitializeComponent();
        }
        public void MostrarChofer(string valor)
        {
            dataGridView1.DataSource = oodln.ViewCarreraFiltro(valor);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MostrarChofer(textBox1.Text);
        }

        private void frmChofer_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = oodln.ViewCarrera();
        }
    }
}
