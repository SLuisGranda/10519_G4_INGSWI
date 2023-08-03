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
    public partial class PClienteActualizar : Form
    {
        public PClienteActualizar()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCedulaRUC.TextLength == 0)
            {
                Util.mensajeExclamacion("¡Ingrese el número de cédula o R.U.C. del cliente que desea actualizar!");
                return;
            }

            DataTable dataCliente = NCliente.consultar(txtCedulaRUC.Text);
            if (dataCliente.Rows.Count == 1 && (txtCedulaRUC.Text.Length == 10 || txtCedulaRUC.Text.Length == 13))
            {
                DataRow dataRow = dataCliente.Rows[0];
                txtNombre.Text = dataRow["Nombre"].ToString();
                txtApellido.Text = dataRow["Apellido"].ToString();
                txtTelefono.Text = dataRow["Teléfono"].ToString();
                txtDireccion.Text = dataRow["Dirección"].ToString();

                txtCedulaRUC.Enabled = false;
                btnBuscar.Enabled = false;
            }
            else
            {
                Util.mensajeError("¡El cliente no se encuentra registrado en la base de datos!");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                string resultado = NCliente.actualizar(txtCedulaRUC.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccion.Text);
                if (resultado.Equals("OK"))
                {
                    Util.mensajeInformativo("¡Cliente actualizado con éxito!");
                    limpiarCajasTexto();

                }
                else
                {
                    Util.mensajeError(resultado);
                }
            }
        }

        private bool validarCampos()
        {
            if (txtNombre.Text == "" || txtApellido.Text == "")
            {
                Util.mensajeError("¡Se debe llenar todos los campos obligatorios (*)!");
                return false;
            }
            else if (txtTelefono.TextLength != 10 && txtTelefono.TextLength != 7 && txtTelefono.TextLength != 9)
            {
                Util.mensajeError("¡El teléfono ingresado es incorrecto!");
                return false;
            }
            return true;
        }

        private void limpiarCajasTexto()
        {
            txtCedulaRUC.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtCedulaRUC.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            limpiarCajasTexto();
        }

        private void txtCedulaRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.validarCampoEntero(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.validarCampoEntero(e);
        }
    }
}
