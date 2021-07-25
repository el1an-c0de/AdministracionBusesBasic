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
    public partial class frmEditBus : Form
    {
        public int opc;
        public Buses auxiliar = null;
        public frmEditBus()
        {
            InitializeComponent();
        }
        public Buses crearObjeto()
        {
            int idBuses = int.Parse(txtIDBus.Text);
            string placa = txtPlaca.Text;
            string modelo = txtModelo.Text;
            string dueno = txtDueno.Text;
            int nobus = int.Parse(txtNumeroBus.Text);
            Buses op = new Buses(idBuses, placa, modelo, dueno, nobus);

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
            if (txtDueno.Text.Trim().Length == 0 ||
                txtIDBus.Text.Trim().Length == 0 ||
                txtModelo.Text.Trim().Length == 0 ||
                txtNumeroBus.Text.Trim().Length == 0 ||
                txtPlaca.Text.Trim().Length == 0)
            {
                verificar = false;
            }
            return verificar;
        }
        private void verDatos()
        {
            txtDueno.Text = auxiliar.Dueno;
            txtIDBus.Text = Convert.ToString( auxiliar.IdBus);
            txtModelo.Text = auxiliar.Modelo;
            txtPlaca.Text = auxiliar.Placa;
            txtNumeroBus.Text = Convert.ToString(auxiliar.NoBus);
        }

        private void frmEditBus_Load(object sender, EventArgs e)
        {
            if (opc == 0 && auxiliar != null)
            {
                label1.Text = "ACTUALIZAR BUS";
                verDatos();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
