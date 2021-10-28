using AppCore.Interfaces;
using Domain.Entities;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActivosFijos
{
    public partial class FrmGestionActivos : Form
    {
        private IActivoFijoService activoFijoService;
        public FrmGestionActivos(IActivoFijoService activoFijoService)
        {
            this.activoFijoService = activoFijoService;
            InitializeComponent();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregarActivo frmAgregarActivo = new FrmAgregarActivo();
            frmAgregarActivo.afService = activoFijoService;
            frmAgregarActivo.ShowDialog();

            Print();
        }

        private void Print()
        {
            ActivoFijo[] activoFijos = activoFijoService.FindAll();
            if (activoFijos == null)
            {
                rtbImprimir.Text = $"Lista de activos vacia.";
                return;
            }
            string text = string.Format("{0,5:d} {1,-20} {2,-15} {3,5:f} {4,-30:d} {5,4:d} \n", "Id", "Codigo", "Nombre", "Valor", "Fecha Adquisicion", "Tipo Activo");
            rtbImprimir.Text = text;
            Depreciacion depreciacion = new Depreciacion();
            foreach (ActivoFijo af in activoFijos)
            {
                rtbImprimir.AppendText(af.ToString());
                rtbImprimir.AppendText($"{Environment.NewLine}");
                int i = 1;
                foreach (decimal d in depreciacion.Depreciar(af))
                {
                    rtbImprimir.AppendText($"{i++} =>  {d} \n");
                }
            }
        }
    }
}
