using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class PEmpleadoConsultar : Form
    {
        public PEmpleadoConsultar()
        {
            InitializeComponent();
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            if (txtCedula.Text.Length >= 2)
                dataEmpleados.DataSource = NEmpleado.consultar(txtCedula.Text);

            if (dataEmpleados.Rows.Count == 0 && (txtCedula.Text.Length == 10))
                Util.mensajeError("¡El cliente no se encuentra registrado en la base de datos!");
        }

        private void PEmpleadoConsultar_Load(object sender, EventArgs e)
        {
            dataEmpleados.DataSource = NEmpleado.consultar(txtCedula.Text);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            txtCedula.Clear();
            dataEmpleados.DataSource = NEmpleado.consultar(txtCedula.Text);
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.validarCampoEntero(e);
        }
    }
}
