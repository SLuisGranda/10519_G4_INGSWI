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
    public partial class PUsuarioActualizar : Form
    {
        public PUsuarioActualizar()
        {
            InitializeComponent();
        }

        private void PUsuarioActualizar_Load(object sender, EventArgs e)
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
            cmbEmpleados.DataSource = NUsuario.consultar("");
            cmbEmpleados.DisplayMember = "Empleado";
            cmbEmpleados.ValueMember = "Cédula";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                string resultado = NUsuario.actualizar(cmbEmpleados.SelectedValue.ToString(), txtNick.Text, txtPassword.Text);
                if (resultado.Equals("OK"))
                {
                    Util.mensajeInformativo("¡Usuario actualizado con éxito!");
                    limpiarCajasTexto();
                    llenarComboEmpleados();
                }
                else
                {
                    Util.mensajeError(resultado);
                }
            }
        }

        private bool validarCampos()
        {
            if (txtNick.Text == "" || txtPassword.Text == "")
            {
                Util.mensajeError("¡Se debe llenar todos los campos obligatorios (*)!");
                return false;
            }
            return true;
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

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            limpiarCajasTexto();
            llenarComboEmpleados();
        }
    }
}
