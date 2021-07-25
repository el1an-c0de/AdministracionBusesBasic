using ProyectoPA.Entidades;
using ProyectoPA.Logica;
using ProyectoPA.Reporte;
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
    public partial class frmAdmin : Form
    {
        public int idseleccionado = -1;
        CarreraLN oodln = new CarreraLN();
        RutaLN rodln = new RutaLN();
        ChoferLN codln = new ChoferLN();
        BusLN bodln = new BusLN();
        
        public Carrera auxiliar = null;
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void btnChofer_Click(object sender, EventArgs e)
        {
            frmAdmChofer c = new frmAdmChofer();
            c.Show();
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            frmAmdRuta r = new frmAmdRuta();
            r.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAmdBus r = new frmAmdBus();
            r.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form1 a = new Form1();
            a.bntIngresar.Visible = true;
            a.groupBox1.Visible = true;
            a.label1.Visible = true;
            Close();
        }
        public void MostrarComboRuta()
        {
            cmbRuta.DataSource = rodln.ViewRuta();
            cmbRuta.DisplayMember = "Nombre";
            cmbRuta.ValueMember = "IdRuta";
        }

        public void MostrarComboChofer()
        {
            cmbChofer.DataSource = codln.ViewChofer();
            cmbChofer.DisplayMember = "Nombre";
            cmbChofer.ValueMember = "IdChofer";
        }

        public void MostrarComboBus()
        {
            cmbBus.DataSource = bodln.ViewBus();
            cmbBus.DisplayMember = "Placa";
            cmbBus.ValueMember = "IdBus";
        }

        public void Nuevo()
        {
            try
            {
                if (validarDatos())
                {
                    Carrera objeto = crearObjeto();
                    oodln.CreateCarrera(objeto);

                    MessageBox.Show("Se ha ingresado la carrera...");
                }
                else
                    MessageBox.Show("Los campos con (*) son obligatorios");
                dataGridView1.DataSource = oodln.ViewCarrera();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar la carrera");
            }
        }

        public Carrera crearObjeto()
        {
            int idcarrera = int.Parse(txtIdCarrera.Text);
            int idbus = Convert.ToInt32( cmbBus.SelectedValue.ToString());
            int idruta = Convert.ToInt32(cmbRuta.SelectedValue.ToString());
            int idchofer = Convert.ToInt32(cmbChofer.SelectedValue.ToString());
            DateTime horanetrada = Convert.ToDateTime( dtpEntrada.Value.ToString());
            DateTime horasalida = Convert.ToDateTime(dtpSalida.Value.ToString());
            string estado= Convert.ToString( cmbEstado.SelectedItem.ToString());
            Carrera op = new Carrera(idcarrera, horasalida, horanetrada, estado, idbus, idruta, idchofer);

            return op;
        }

        private bool validarDatos()
        {
            bool verificar = true;
            if (txtIdCarrera.Text.Trim().Length == 0 ||
                cmbBus.Text.Trim().Length == 0 ||
                cmbChofer.Text.Trim().Length == 0 ||
                cmbEstado.Text.Trim().Length == 0 ||
                cmbRuta.Text.Trim().Length == 0 )
            {
                verificar = false;
            }
            return verificar;
        }


        public void Modificar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {                    
                    dataGridView1.DataSource = oodln.ViewCarreraFiltro(txtBuscarCarrera.Text);
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
                    auxiliar = dataGridView1.CurrentRow.DataBoundItem as Carrera;

                    Carrera objeto = crearObjeto();
                    oodln.UpdateCarrera(objeto);
                    MessageBox.Show("Se ha actualizado la carrera seleccionada...");
                    
                }
                else
                    MessageBox.Show("Seleccione...");
                MostrarCarrera(txtBuscarCarrera.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Actualizar()
        {
            MostrarComboRuta();
            MostrarComboChofer();
            MostrarComboBus();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            MostrarComboRuta();
            MostrarComboChofer();
            MostrarComboBus();
            dataGridView1.DataSource = oodln.ViewCarrera();
            if (dataGridView1.SelectedRows.Count == 1)
            {
                idseleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            MostrarCarrera(txtBuscarCarrera.Text);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                idseleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            auxiliar = dataGridView1.CurrentRow.DataBoundItem as Carrera;
            txtIdCarrera.Text = Convert.ToString(auxiliar.IdCarrera);
            cmbBus.Text = Convert.ToString(auxiliar.IdBus);
            cmbChofer.Text = Convert.ToString(auxiliar.IdChofer);
            cmbEstado.Text = Convert.ToString(auxiliar.Estado);
            cmbRuta.Text = Convert.ToString(auxiliar.IdRuta);
            dtpEntrada.Value = auxiliar.HoraEntrada;
            dtpSalida.Value = auxiliar.HoraSalida;
        }
        public void MostrarCarrera(string valor)
        {
            dataGridView1.DataSource = oodln.ViewCarreraFiltro(valor);
        }
        private void txtBuscarCarrera_TextChanged(object sender, EventArgs e)
        {
            MostrarCarrera(txtBuscarCarrera.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmReporteCarrera rc = new frmReporteCarrera();
            rc.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmAdmChofer admchofer = new frmAdmChofer();
            frmAmdBus amdbus = new frmAmdBus();
            frmAmdRuta amdruta = new frmAmdRuta();
            this.Close();
            admchofer.Close();
            amdbus.Close();
            amdruta.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MostrarComboRuta();
            MostrarComboChofer();
            MostrarComboBus();
        }
    }
}
