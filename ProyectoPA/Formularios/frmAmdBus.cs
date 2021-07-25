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
    public partial class frmAmdBus : Form
    {
        BusLN oppln = new BusLN();
        public int idseleccionado = -1;
        public frmAmdBus()
        {
            InitializeComponent();
        }
        public void Nuevo()
        {
            try
            {
                frmEditBus frm = new frmEditBus();

                frm.opc = 1;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Buses objeto = frm.crearObjeto();
                    oppln.CreateBuses(objeto);
                    frm.Close();
                    
                    MessageBox.Show("Se ha ingresado el bus...");
                }
                else
                {
                    frm.Close();
                }
                MostrarBus(txtBuscarBus.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el bus");
            }
        }

        public void Modificar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditBus frm = new frmEditBus();
                    frm.opc = 0;

                    dataGridView1.DataSource = oppln.ViewBusFiltro(txtBuscarBus.Text);
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
                    frm.auxiliar = dataGridView1.CurrentRow.DataBoundItem as Buses;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        Buses objeto = frm.crearObjeto();
                        oppln.UpdateBuses(objeto);
                        
                        frm.Close();
                        MessageBox.Show("Se ha actualizado el bus seleccionado...");
                    }
                    else
                    {
                        frm.Close();
                    }
                }
                else
                    MessageBox.Show("Seleccione...");
                MostrarBus(txtBuscarBus.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el bus");
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
                        dataGridView1.DataSource = oppln.ViewBusFiltro(txtBuscarBus.Text);
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
                        Buses objeto = dataGridView1.CurrentRow.DataBoundItem as Buses;
                        oppln.DeleteBuses(objeto);
                        
                        MessageBox.Show("Se ha eliminado el bus seleccionado...");

                    }
                    else{ }
                }
                else
                    MessageBox.Show("Seleccione...");
                MostrarBus(txtBuscarBus.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el bus");
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
        public void MostrarBus(string valor)
        {
            dataGridView1.DataSource = oppln.ViewBusFiltro(valor);
        }
        private void txtBuscarBus_TextChanged(object sender, EventArgs e)
        {
            MostrarBus(txtBuscarBus.Text);
        }

        private void frmAmdBus_Load(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                idseleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            MostrarBus(txtBuscarBus.Text);
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
