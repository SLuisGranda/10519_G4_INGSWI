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
    public partial class PEmpleadoActualizar : Form
    {
        public PEmpleadoActualizar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombres.TextLength == 0)
            {
                Util.mensajeError("¡Primero debe buscar el empleado que desea actualizar!");
                return;
            }

            if (validarCampos())
            {
                string resultado = NEmpleado.actualizar(txtCedula.Text, txtNombres.Text, txtApellidos.Text, txtFechaNacimiento.Value, txtCelular.Text, txtConvencional.Text, txtDireccion.Text, cmbCargos.SelectedValue.ToString(), rdBtnActivo.Checked);
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
            if (txtNombres.Text == "" || txtApellidos.Text == "")
            {
                //valdiar: txtFechaNacimiento.Value y rdBtnActivo.Checked
                Util.mensajeError("¡Se debe llenar todos los campos obligatorios (*)!");
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
            cmbCargos.DataSource = null;
            cmbCargos.Items.Clear();
            txtCedula.Enabled = true;
            btnBuscar.Enabled = true;
            rdBtnActivo.Checked = false;
            rdBtnInactivo.Checked = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCedula.TextLength == 0)
            {
                Util.mensajeExclamacion("¡Ingrese el número de cédula del empleado que desea actualizar!");
                return;
            }

            DataTable dataCliente = NEmpleado.consultar(txtCedula.Text);
            if (dataCliente.Rows.Count == 1 && txtCedula.Text.Length == 10)
            {
                DataRow dataRow = NEmpleado.consultar(txtCedula.Text).Rows[0];
                txtNombres.Text = dataRow["Nombres"].ToString();
                txtApellidos.Text = dataRow["Apellidos"].ToString();
                txtFechaNacimiento.Text = dataRow["Fecha de Nacimiento"].ToString();
                txtCelular.Text = dataRow["Teléfono Celular"].ToString();
                txtConvencional.Text = dataRow["Teléfono Convencional"].ToString();
                txtDireccion.Text = dataRow["Dirección"].ToString();
                llenarComboCargos();
                cmbCargos.SelectedItem = dataRow["Cargo"].ToString();
                rdBtnActivo.Checked = dataRow["Estado"].ToString() == "True" ? true : false;
                if (!rdBtnActivo.Checked)
                    rdBtnInactivo.Checked = true;

                txtCedula.Enabled = false;
                btnBuscar.Enabled = false;
            }
            else
            {
                Util.mensajeError("¡El cliente no se encuentra registrado en la base de datos!");
            }
        }

        private void PEmpleadoActualizar_Load(object sender, EventArgs e)
        {
            rdBtnActivo.Checked = false;
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.validarCampoEntero(e);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            limpiarCajasTexto();
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

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.validarCampoEntero(e);
        }

        private void txtConvencional_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.validarCampoEntero(e);
        }
    }
}
