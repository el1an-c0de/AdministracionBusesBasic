using ProyectoPA.Entidades;
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
    public partial class frmAdmChofer : Form
    {
        public int idseleccionado = -1;
        ChoferLN opln = new ChoferLN();
        SesionLN oppln = new SesionLN();
        frmAdmin a = new frmAdmin();
        public frmAdmChofer()
        {
            InitializeComponent();
        }

        public void Nuevo()
        {
            try
            {
                frmEditChofer frm = new frmEditChofer();

                frm.opc = 1;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Chofer objeto = frm.crearObjeto();
                    Sesion objeto2 = frm.crearSesion();
                    opln.CreateChofer(objeto);
                    oppln.CreateSesion(objeto2);
                    a.Actualizar();
                    frm.Close();
                    MessageBox.Show("Se ha ingresado el Chofer...");
                }
                else
                {
                    frm.Close();
                }
                MostrarChofer(txtBuscarChofer.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Modificar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditChofer frm = new frmEditChofer();
                    frm.Text = "Actualizar Chofer";
                    frm.opc = 0;

                    foreach (var item in oppln.ViewSesion())
                    {
                        if (item.Usuario == dataGridView1.CurrentRow.Cells[4].Value.ToString())
                        {
                            frm.cedula = item.Usuario;
                            string ced = item.Usuario;

                            break;
                        }
                    }

                    dataGridView1.DataSource = opln.ViewChoferFiltro(txtBuscarChofer.Text);
                    if (idseleccionado != -1)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (idseleccionado == Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString()))
                            {

                                dataGridView1.Rows[i].Selected = true;
                                dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[1];
                                break;
                            }
                        }
                    }

                    frm.auxiliar = dataGridView1.CurrentRow.DataBoundItem as Chofer;
                    frm.auxsesion = dataGridView1.CurrentRow.DataBoundItem as Sesion;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        Chofer objeto = frm.crearObjeto();
                        opln.UpdateChofer(objeto);
                        Sesion objeto2 = frm.crearSesion();
                        oppln.UpdateSesion(objeto2);
                        a.Actualizar();
                        frm.Close(); 
                        MessageBox.Show("Se ha actualizado el Chofer seleccionado...");
                    }
                    else
                    {
                        frm.Close();
                    }
                }
                else
                    MessageBox.Show("Seleccione...");
                MostrarChofer(txtBuscarChofer.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el chofer");
            }
        }


        private void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditChofer frm = new frmEditChofer();
                    frm.Text = "Eliminar Chofer";
                    frm.opc = 1;
                    var res = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        dataGridView1.DataSource = opln.ViewChoferFiltro(txtBuscarChofer.Text);
                        if (idseleccionado != -1)
                        {
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (idseleccionado == Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString()))
                                {
                                    dataGridView1.Rows[i].Selected = true;
                                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[1];
                                    break;
                                }
                            }
                        }
                        //Chofer objeto = dataGridView1.CurrentRow.DataBoundItem as Chofer;
                        //Sesion objeto2 = dataGridView1.CurrentRow.DataBoundItem as Sesion;
                        //opln.DeleteChofer(objeto);
                        //oppln.DeleteSesion(objeto2);

                        frm.auxiliar = dataGridView1.CurrentRow.DataBoundItem as Chofer;
                        frm.auxsesion = dataGridView1.CurrentRow.DataBoundItem as Sesion;
                        frm.ShowDialog();
                        
                        if (frm.DialogResult == DialogResult.OK)
                        {
                            //Chofer objeto = dataGridView1.CurrentRow.DataBoundItem as Chofer;
                            //opln.DeleteChofer(objeto);
                            Chofer objeto = frm.crearObjeto();
                            opln.DeleteChofer(objeto);
                            Sesion objeto2 = frm.crearSesion();
                            oppln.DeleteSesion(objeto2);
                            a.Actualizar();
                            frm.Close();
                            MessageBox.Show("Se ha eliminado el Chofer seleccionado...");
                        }
                        a.Actualizar();
                    }
                    else { }
                        
                }
                else
                    MessageBox.Show("Seleccione...");
                MostrarChofer(txtBuscarChofer.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el chofer");
            }
        }
        

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Modificar();
            
        }
        public void MostrarChofer(string valor)
        {
            dataGridView1.DataSource = opln.ViewChoferFiltro(valor);
        }

        private void txtBuscarChofer_TextChanged(object sender, EventArgs e)
        {
            MostrarChofer(txtBuscarChofer.Text);
        }

        private void frmAdmChofer_Load(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                idseleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            MostrarChofer(txtBuscarChofer.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                idseleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }
    }
}
