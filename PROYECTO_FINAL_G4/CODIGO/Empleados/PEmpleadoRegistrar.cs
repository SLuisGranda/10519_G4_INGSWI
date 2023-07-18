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
    public partial class PEmpleadoRegistrar : Form
    {
        public PEmpleadoRegistrar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                string resultado = NEmpleado.registrar(txtCedula.Text, txtNombres.Text, txtApellidos.Text, txtFechaNacimiento.Value, txtCelular.Text, txtConvencional.Text, txtDireccion.Text, cmbCargos.SelectedValue.ToString(), rdBtnActivo.Checked);
                if (resultado.Equals("OK"))
                {
                    Util.mensajeInformativo("¡Empleado registrado con éxito!");
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
            if (txtCedula.Text == "" || txtNombres.Text == "" || txtApellidos.Text == "")
            {
                //valdiar: txtFechaNacimiento.Value y rdBtnActivo.Checked
                Util.mensajeError("¡Se debe llenar todos los campos obligatorios (*)!");
                return false;
            }
            else if (txtCedula.Text.Length != 10)
            {
                Util.mensajeError("¡El número de cédula debe ser de 10 dígitos!");
                return false;
            }
            else if (!Util.esMayorEdad(txtFechaNacimiento))
            {
                Util.mensajeError("¡El empleado debe ser mayor de edad!");
                return false;
            }
            else if (txtCelular.TextLength != 10)
            {
                Util.mensajeError("¡El número de télefono celular es incorrecto!");
                return false;
            }
            else if (txtConvencional.TextLength != 7 && txtConvencional.TextLength != 9)
            {
                Util.mensajeError("¡El número de télefono convencional es incorrecto!");
                return false;
            }
            else if (!Util.validarCedula(txtCedula.Text))
            {
                Util.mensajeError("¡El número de cédula es incorrecto!");
                return false;
            }
            return true;
        }

        private void limpiarCajasTexto()
        {
            txtCedula.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtFechaNacimiento.Value = DateTime.Today;
            txtCelular.Text = "";
            txtConvencional.Text = "";
            txtDireccion.Text = "";
            llenarComboCargos();
            rdBtnActivo.Checked = true;
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.validarCampoLetras(e);
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.validarCampoLetras(e);

        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.validarCampoEntero(e);
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.validarCampoEntero(e);
        }

        private void txtConvencional_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.validarCampoEntero(e);
        }

        private void PEmpleadoRegistrar_Load(object sender, EventArgs e)
        {
            llenarComboCargos();
        }
        private void llenarComboCargos()
        {
            DataTable dataCargos = NParametro.consultar("Cargo");
            if (dataCargos.Rows.Count == 0)
            {
                List<string> listaCargos = new List<string>();
                listaCargos.Add("Vendedor");
                listaCargos.Add("Administrador");
                listaCargos.Add("Transportista");

                cmbCargos.DataSource = listaCargos;
            }
            else
            {
                cmbCargos.DataSource = dataCargos;
                cmbCargos.DisplayMember = "Nombre";
                cmbCargos.ValueMember = "Valor";
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            limpiarCajasTexto();
        }
    }
}
