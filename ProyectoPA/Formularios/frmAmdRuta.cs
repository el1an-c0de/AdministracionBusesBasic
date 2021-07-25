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
    public partial class frmAmdRuta : Form
    {
        public int idseleccionado = -1;
        RutaLN opln = new RutaLN();
        public frmAmdRuta()
        {
            InitializeComponent();
        }

        public void Nuevo()
        {
            try
            {
                frmEditRuta frm = new frmEditRuta();

                frm.opc = 1;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Ruta objeto = frm.crearObjeto();
                    opln.CreateRuta(objeto);
                    frm.Close();
                    MessageBox.Show( "Se ha ingresado la ruta...");
                }
                else
                {
                    frm.Close();
                }
                MostrarRuta(txtBuscarRuta.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar la ruta");
            }
        }

        public void Modificar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditRuta frm = new frmEditRuta();
                    frm.opc = 0;

                    dataGridView1.DataSource = opln.ViewRutaFiltro(txtBuscarRuta.Text);
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
                    frm.auxiliar = dataGridView1.CurrentRow.DataBoundItem as Ruta;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        Ruta objeto = frm.crearObjeto();
                        opln.UpdateRuta(objeto);
                        frm.Close();
                        MessageBox.Show("Se ha actualizado la ruta seleccionado...");
                    }
                    else
                    {
                        frm.Close();
                    }
                }
                else
                    MessageBox.Show("Seleccione...");
                MostrarRuta(txtBuscarRuta.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la ruta");
            }
        }

        private void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        dataGridView1.DataSource = opln.ViewRutaFiltro(txtBuscarRuta.Text);
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
                        Ruta objeto = dataGridView1.CurrentRow.DataBoundItem as Ruta;
                        opln.DeleteRuta(objeto);
                        MessageBox.Show("Se ha eliminado la ruta seleccionado...");

                    }
                    
                        
                }
                else
                    MessageBox.Show("Seleccione...");
                MostrarRuta(txtBuscarRuta.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la ruta");
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
        public void MostrarRuta(string valor)
        {
            dataGridView1.DataSource = opln.ViewRutaFiltro(valor);
        }

        private void txtBuscarRuta_TextChanged(object sender, EventArgs e)
        {
            MostrarRuta(txtBuscarRuta.Text);
        }

        private void frmAmdRuta_Load(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                idseleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            MostrarRuta(txtBuscarRuta.Text);
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
