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

namespace ProyectoPA.Reporte
{
    public partial class frmReporteCarrera : Form
    {
        public frmReporteCarrera()
        {
            InitializeComponent();
        }
        CarreraLN ocln = new CarreraLN();
        private void frmReporteCarrera_Load(object sender, EventArgs e)
        {
            DSReportesCarrera ds = new DSReportesCarrera();
            try{
                List<Carrera> lc = ocln.ViewCarrera();
                foreach (Carrera ap in lc)
                {
                    ds.Carrera.AddCarreraRow(ap.IdCarrera, ap.HoraSalida, ap.HoraEntrada, ap.Estado, ap.IdBus, ap.IdRuta, ap.IdChofer);
                }
                CRCarrera rct = new CRCarrera();
                rct.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rct;

            }
            catch(Exception men)
            {
                MessageBox.Show(men.ToString());
            }
        }
    }
}
