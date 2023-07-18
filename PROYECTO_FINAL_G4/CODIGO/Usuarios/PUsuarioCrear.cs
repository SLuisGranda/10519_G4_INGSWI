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
    public partial class PUsuarioCrear : Form
    {
        public PUsuarioCrear()
        {
            InitializeComponent();
        }

        private void PUsuarioCrear_Load(object sender, EventArgs e)
        {
            llenarComboEmpleados();
        }

        private void llenarComboEmpleados()
        {
            cmbEmpleados.DataSource = NEmpleado.consultar2(""); ;
            cmbEmpleados.DisplayMember = "Empleado";
            cmbEmpleados.ValueMember = "Cédula";
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            DataTable dataUser = NUsuario.consultar(cmbEmpleados.SelectedValue.ToString());
            if (dataUser.Rows.Count != 0)
            {
                Util.mensajeError("¡El empleado ingresado ya tiene una cuenta disponible!");
                return;
            }

            if (validarCampos())
            {
                string resultado = NUsuario.crear(cmbEmpleados.SelectedValue.ToString(), txtNick.Text, txtPassword.Text);
                if (resultado.Equals("OK"))
                {
                    Util.mensajeInformativo("¡Usuario creado con éxito!");
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
            llenarComboEmpleados();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            limpiarCajasTexto();
        }
    }
}
