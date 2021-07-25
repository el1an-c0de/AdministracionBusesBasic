using ProyectoPA.BD;
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
    public partial class frmSesion : Form
    {
        public frmSesion()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        Form1 b = new Form1();
        DataClasses1DataContext DB = new DataClasses1DataContext();
        private void bntIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contra = txtContra.Text;
            try
            {
                var user = (from s in DB.Sesion
                            where s.Usuario == txtUsuario.Text
                            select s).First();

                if (user.Contrasena == txtContra.Text && user.Usuario == txtUsuario.Text && user.Tipo == "Admin")
                {
                    
                    Form1 a = new Form1();
                    //a.Admin();
                    
                    frmAdmin c = new frmAdmin();
                    c.Show();
                    
                }
                else if (user.Contrasena == txtContra.Text && user.Usuario == txtUsuario.Text && user.Tipo == "Chofer")
                {
                    Form1 a = new Form1();
                    //a.Chofer();
                    frmChofer c = new frmChofer();
                    c.Show();

                }
                else
                {
                    MessageBox.Show("Error al iniciar sesion, verifique sus datos");
                    txtContra.Text = "";
                    txtUsuario.Text = "";
                }
            }
            catch (Exception ex)
            {
                //throw new DatosExcepciones("Error al iniciar sesion, porfavor intente nuevamente", ex);
                MessageBox.Show("Error al iniciar sesion, porfavor intente de nuevamente");
                txtContra.Text = "";
                txtUsuario.Text = "";
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
