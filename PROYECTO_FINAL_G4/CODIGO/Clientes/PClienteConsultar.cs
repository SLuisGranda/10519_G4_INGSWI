using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class PClienteConsultar : Form
    {
        public PClienteConsultar()
        {
            InitializeComponent();
        }

        private void PClienteConsultar_Load(object sender, EventArgs e)
        {
            dataClientes.DataSource = NCliente.consultar(txtCedulaRUC.Text);
        }

        private void txtCedulaRUC_TextChanged(object sender, EventArgs e)
        {
            if (txtCedulaRUC.Text.Length >= 2)
                dataClientes.DataSource = NCliente.consultar(txtCedulaRUC.Text);

            if (dataClientes.Rows.Count == 0 && (txtCedulaRUC.Text.Length == 10 || txtCedulaRUC.Text.Length == 13))
                Util.mensajeError("¡El cliente no se encuentra registrado en la base de datos!");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCedulaRUC.Text = "";
        }

        private void dataClientes_DoubleClick(object sender, EventArgs e)
        {
            Program.datosCliente(dataClientes.CurrentRow.Cells[0].Value.ToString(), dataClientes.CurrentRow.Cells[1].Value.ToString(), dataClientes.CurrentRow.Cells[2].Value.ToString(), dataClientes.CurrentRow.Cells[3].Value.ToString(), dataClientes.CurrentRow.Cells[4].Value.ToString());
            this.Close();
        }

        private void txtCedulaRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.validarCampoEntero(e);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            txtCedulaRUC.Clear();
            dataClientes.DataSource = NCliente.consultar(txtCedulaRUC.Text);
        }
    }
}
