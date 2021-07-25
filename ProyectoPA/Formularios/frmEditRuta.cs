using ProyectoPA.Entidades;
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
    public partial class frmEditRuta : Form
    {
        public int opc;
        public Ruta auxiliar = null;
        public frmEditRuta()
        {
            InitializeComponent();
        }
        public Ruta crearObjeto()
        {
            int idRuta = int.Parse(txtIDRuta.Text);
            string nombre = txtNombreRuta.Text;
            double tarifa = Convert.ToDouble( txtTarifa.Text);

            Ruta op = new Ruta(idRuta,nombre,tarifa);

            return op;
        }

        private void guardar()
        {
            try
            {
                if (validarDatos())
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Los campos con (*) son obligatorios");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool validarDatos()
        {
            bool verificar = true;
            if (txtIDRuta.Text.Trim().Length == 0 ||
                txtNombreRuta.Text.Trim().Length == 0 || 
                txtTarifa.Text.Trim().Length == 0 )
            {
                verificar = false;
            }
            return verificar;
        }

        private void verDatos()
        {
            txtIDRuta.Text = Convert.ToString(auxiliar.IdRuta);
            txtNombreRuta.Text = auxiliar.Nombre;
            txtTarifa.Text = Convert.ToString( auxiliar.Tarifa);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void frmEditRuta_Load(object sender, EventArgs e)
        {
            if (opc == 0 && auxiliar != null)
            {
                label1.Text = "ACTUALIZAR RUTA";
                verDatos();
            }
        }
    }
}
