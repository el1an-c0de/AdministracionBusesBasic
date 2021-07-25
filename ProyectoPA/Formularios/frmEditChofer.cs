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
    public partial class frmEditChofer : Form
    {
        public int opc;
        public string cedula;
        public Chofer auxiliar = null;
        public Sesion auxsesion = null;
        public frmEditChofer()
        {
            InitializeComponent();
        }
        public Entidades.Chofer crearObjeto()
        {
            int idChofer = int.Parse(txtIDChofer.Text);
            string nombre = txtNombreChofer.Text;
            string apellidos = txtApellidosChofer.Text;
            string tipoLicencia = txtTipoLicencia.Text;
            string cedula = txtCedula.Text;

            Entidades.Chofer op = new Entidades.Chofer(idChofer, nombre, apellidos, tipoLicencia, cedula);

            return op;
        }

        public Sesion crearSesion()
        {
            int idsesion = Convert.ToInt32( txtIDChofer.Text);
            string usuario = txtCedula.Text;
            string contrasena = txtCedula.Text;
            string tipo = "Chofer";

            Sesion opp = new Sesion(idsesion, usuario, contrasena, tipo);

            return opp;
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
                MessageBox.Show("Error al guardar el chofer");
            }

        }

        private bool validarDatos()
        {
            bool verificar = true;
            if (txtApellidosChofer.Text.Trim().Length == 0 ||
                txtCedula.Text.Trim().Length == 0 || 
                txtIDChofer.Text.Trim().Length == 0 ||
                txtNombreChofer.Text.Trim().Length == 0 || 
                txtTipoLicencia.Text.Trim().Length == 0)
            {
                verificar = false;
            }
            return verificar;
        }

        private void verDatos()
        {
            txtIDChofer.Text = Convert.ToString(auxiliar.IdChofer);
            txtNombreChofer.Text = auxiliar.Nombre;
            txtApellidosChofer.Text = auxiliar.Apellidos;
            txtTipoLicencia.Text = auxiliar.TipoLicencia;
            txtCedula.Text = auxiliar.Cedula;
            //txtCedula.Text = Convert.ToString(cedula);
        }

        private void frmEditChofer_Load(object sender, EventArgs e)
        {
            if (opc == 0 && auxiliar != null)
            {
                label1.Text = "ACTUALIZAR CHOFER";
                button1.Text = "ACTUALIZAR";
                verDatos();
            }
            if(opc == 1 && auxiliar != null)
            {
                label1.Text = "ELIMINAR CHOFER";
                txtIDChofer.Enabled = false;
                txtNombreChofer.Enabled = false;
                txtApellidosChofer.Enabled = false;
                txtTipoLicencia.Enabled = false;
                txtCedula.Enabled = false;
                button1.Text = "ELIMINAR";
                verDatos();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
