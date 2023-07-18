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
    public partial class PUsuarioConsultar : Form
    {
        public PUsuarioConsultar()
        {
            InitializeComponent();
        }

        private void PUsuarioConsultar_Load(object sender, EventArgs e)
        {
            dataUsuarios.DataSource = NUsuario.consultar("");
        }
    }
}
