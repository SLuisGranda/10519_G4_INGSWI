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
    public partial class PUsuarioEliminar : Form
    {
        public PUsuarioEliminar()
        {
            InitializeComponent();
        }

        private void PUsuarioEliminar_Load(object sender, EventArgs e)
        {
            llenarComboEmpleados();
            if (cmbEmpleados.Items.Count != 0)
            {
                DataTable dataEmpleados = NUsuario.consultar(cmbEmpleados.SelectedValue.ToString());
                DataRow dataRow = dataEmpleados.Rows[0];
                txtNick.Text = dataRow["Nick"].ToString();
                txtPassword.Text = dataRow["Password"].ToString();
            }
        }
        private void llenarComboEmpleados()
        {
            cmbEmpleados.DataSource = NUsuario.consultar(""); ;
            cmbEmpleados.DisplayMember = "Empleado";
            cmbEmpleados.ValueMember = "Cédula";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string resultado = NUsuario.eliminar(cmbEmpleados.SelectedValue.ToString());
            if (resultado.Equals("OK"))
            {
                Util.mensajeInformativo("¡Usuario eliminado con éxito!");
                limpiarCajasTexto();
                llenarComboEmpleados();
            }
            else
            {
                Util.mensajeError(resultado);
            }
        }
        private void limpiarCajasTexto()
        {
            txtNick.Text = "";
            txtPassword.Text = "";
        }

        private void cmbEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataEmpleados = NUsuario.consultar(cmbEmpleados.SelectedValue.ToString());
            if (dataEmpleados.Rows.Count != 0)
            {
                DataRow dataRow = dataEmpleados.Rows[0];
                txtNick.Text = dataRow["Nick"].ToString();
                txtPassword.Text = dataRow["Password"].ToString();
            }
        }
    }
}
