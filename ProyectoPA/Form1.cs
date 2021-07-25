using ProyectoPA.BD;
using ProyectoPA.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPA
{
    public partial class Form1 : Form
    {
        frmAdmin admin = new frmAdmin();
        frmChofer chof = new frmChofer();
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void panelAdmin()
        {
            frmAdmin a = new frmAdmin();
            Algoritmos.Algoritmos.addFormulario(panel2, a);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }
        DataClasses1DataContext DB = new DataClasses1DataContext();

        private void bntIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contra = txtContra.Text;

            var user = (from s in DB.Sesion
                        where s.Usuario == txtUsuario.Text
                        select s).First();
            try
            {

            if (user.Contrasena == txtContra.Text && user.Usuario == txtUsuario.Text && user.Tipo == "Admin")
            {
                MessageBox.Show("Bienvenido " + user.Usuario + " :D");
                txtContra.Text = "";
                txtUsuario.Text = "";
                lblTitulo.Text = "ADMINISTRACION   BIENVENIDO " + usuario;
                pictureBox2.Image = Image.FromFile("usuario (3).png");
                button1.BackColor = Color.FromArgb(56, 54, 128);
                chof.Hide();
                admin.Show();
            }
            else if (user.Contrasena == txtContra.Text && user.Usuario == txtUsuario.Text && user.Tipo == "Chofer")
            {
                var chofer = (from s in DB.Chofer
                                where s.Cedula == txtUsuario.Text
                                select s).First();
                MessageBox.Show("Bienvenido " + chofer.Nombres + " :D");
                    txtContra.Text = "";
                    txtUsuario.Text = "";
                    lblTitulo.Text = "CHOFERES    BIENVENIDO " + chofer.Nombres;
                    pictureBox2.Image = Image.FromFile("avatar.png");
                    button2.BackColor = Color.FromArgb(56, 54, 128);
                    admin.Hide();
                    chof.Show();
                }
                else
                {
                    MessageBox.Show("Error al iniciar sesion, rectifique los datos");
                    txtContra.Text = "";
                    txtUsuario.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesion, porfavor intente de nuevo");
                txtContra.Text = "";
                txtUsuario.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSesion a = new frmSesion();
            a.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            frmSesion a = new frmSesion();
            a.Show();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Process op = new Process();
            op.StartInfo.FileName = "C:\\Users\\ELIAN\\Documents\\AdministradorDeBusesCoop.DeBusesMachalaCity.chm";
            op.Start();
        }
    }
}
