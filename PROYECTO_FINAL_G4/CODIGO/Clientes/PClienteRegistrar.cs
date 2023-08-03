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
    public partial class PClienteRegistrar : Form
    {
        public PClienteRegistrar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                string resultado = NCliente.registrar(txtCedulaRUC.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccion.Text);
                if (resultado.Equals("OK"))
                {
                    Program.datosCliente(txtCedulaRUC.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccion.Text);
                    Util.mensajeInformativo("¡Cliente registrado con éxito!");
                    limpiarCajasTexto();
                }
                else
                {
                    Util.mensajeError(resultado);
                }
                //interruptor this.Close();
            }

        }

        private bool validarCampos()
        {
            if (txtCedulaRUC.Text == "" || txtNombre.Text == "" || txtApellido.Text == "")
            {
                Util.mensajeError("¡Se debe llenar todos los campos obligatorios (*)!");
                return false;
            }
            else if (txtCedulaRUC.Text.Length != 10 && txtCedulaRUC.Text.Length != 13)
            {
                Util.mensajeError("¡El número de cédula o RUC debe ser de 10 o 13 dígitos respectivamente!");
                return false;
            }
            else if (txtTelefono.TextLength != 10 && txtTelefono.TextLength != 7 && txtTelefono.TextLength != 9)
            {
                Util.mensajeError("¡El teléfono ingresado es incorrecto!");
                return false;
            }
            else if (!Util.validarCedula(txtCedulaRUC.Text.Substring(0, 10)))
            {
                Util.mensajeError("¡El número de cédula o RUC es incorrecto!");
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
        }

        private void txtCedulaRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.validarCampoEntero(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.validarCampoEntero(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.validarCampoLetras(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.validarCampoLetras(e);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            limpiarCajasTexto();
        }

    }
}
