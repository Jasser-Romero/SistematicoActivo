using AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Entities;
using Domain.Enums;

namespace ActivosFijos
{
    public partial class FrmAgregarActivo : Form
    {
        public IActivoFijoService afService { get; set; }
        public FrmAgregarActivo()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            ActivoFijo af = new ActivoFijo()
            {
                Id = afService.GetLastActivoFijoID() + 1,
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Valor = nudValor.Value,
                FechaAdquisicion = dtpFecha.Value,
                TipoActivo = (TipoActivoFijo)cmbTipoActivo.SelectedIndex,
                MetodoDepreciacion = (MetodoDepreciacion)cmbMetodo.SelectedIndex
            };

            afService.Create(af);

            Dispose();
        }

        private void FrmAgregarActivo_Load(object sender, EventArgs e)
        {
            cmbTipoActivo.Items.AddRange(Enum.GetValues(typeof(TipoActivoFijo)).Cast<object>().ToArray());

            cmbMetodo.Items.AddRange(Enum.GetValues(typeof(MetodoDepreciacion)).Cast<object>().ToArray());
        }

        private void CmbMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
