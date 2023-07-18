using CapaNegocio;
using CapaPresentacion;
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
    public partial class PUsuarioIngresar : Form
    {
        public PUsuarioIngresar()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                DataTable dataUsuario = NUsuario.autenticar(txtNick.Text);
                if (dataUsuario.Rows.Count == 0)
                {
                    Util.mensajeError("¡Usuario inválido, nick o password incorrectos!");
                }
                else
                {
                    DataRow dataRow = dataUsuario.Rows[0];
                    if (dataRow["Password"].ToString().Equals(txtPassword.Text))
                    {
                        //ingresando al sistema
                        Program.usuario.CedulaEmpleado = dataRow["Cédula"].ToString();
                        Program.usuario.Nick = dataRow["Nick"].ToString();

                        PMenuPrincipal menuPrincipal = new PMenuPrincipal();
                        menuPrincipal.Show();
                        this.Hide();
                    }
                    else
                    {
                        //solo pass incorrecto
                        Util.mensajeError("¡Usuario inválido, nick o password incorrectos!");
                    }
                }
            }
        }
        private bool validarCampos()
        {
            if (txtNick.Text == "" || txtPassword.Text == "")
            {
                Util.mensajeError("¡Ingrese todos los datos de usuario!");
                return false;
            }
            return true;
        }

        private void PUsuarioIngresar_Load(object sender, EventArgs e)
        {
            DataTable dataUsuarios = NUsuario.consultar("");
            if (dataUsuarios.Rows.Count == 0)
            {
                NCliente.registrar("0000000000", "Consumidor", "Final", "9999999999", "XXXXX");
                NEmpleado.registrar("1111111111", "Admin", "Master", DateTime.Today, "9999999999", "2222222", "XXXXX", "Administrador", true);
                NUsuario.crear("1111111111", "master", "root");

                NParametro.crear("Número de Factura", "1");
                NParametro.crear("I.V.A.", "0,14");
                NParametro.crear("R.U.C.", "1002295598001");
            }
        }
    }
}
