namespace CapaPresentacion
{
    partial class PClienteConsultar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PClienteConsultar));
            this.grBoxListaClientes = new System.Windows.Forms.GroupBox();
            this.dataClientes = new System.Windows.Forms.DataGridView();
            this.grBoxBusquedaCliente = new System.Windows.Forms.GroupBox();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.txtCedulaRUC = new System.Windows.Forms.TextBox();
            this.lblCedulaRUC = new System.Windows.Forms.Label();
            this.grBoxListaClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataClientes)).BeginInit();
            this.grBoxBusquedaCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // grBoxListaClientes
            // 
            this.grBoxListaClientes.Controls.Add(this.dataClientes);
            this.grBoxListaClientes.Location = new System.Drawing.Point(12, 67);
            this.grBoxListaClientes.Name = "grBoxListaClientes";
            this.grBoxListaClientes.Size = new System.Drawing.Size(555, 217);
            this.grBoxListaClientes.TabIndex = 2;
            this.grBoxListaClientes.TabStop = false;
            this.grBoxListaClientes.Text = "Lista de Clientes";
            // 
            // dataClientes
            // 
            this.dataClientes.AllowUserToAddRows = false;
            this.dataClientes.AllowUserToDeleteRows = false;
            this.dataClientes.AllowUserToOrderColumns = true;
            this.dataClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataClientes.Location = new System.Drawing.Point(6, 19);
            this.dataClientes.Name = "dataClientes";
            this.dataClientes.ReadOnly = true;
            this.dataClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataClientes.Size = new System.Drawing.Size(543, 192);
            this.dataClientes.TabIndex = 9;
            this.dataClientes.DoubleClick += new System.EventHandler(this.dataClientes_DoubleClick);
            // 
            // grBoxBusquedaCliente
            // 
            this.grBoxBusquedaCliente.Controls.Add(this.btnRegresar);
            this.grBoxBusquedaCliente.Controls.Add(this.txtCedulaRUC);
            this.grBoxBusquedaCliente.Controls.Add(this.lblCedulaRUC);
            this.grBoxBusquedaCliente.Location = new System.Drawing.Point(196, 12);
            this.grBoxBusquedaCliente.Name = "grBoxBusquedaCliente";
            this.grBoxBusquedaCliente.Size = new System.Drawing.Size(223, 49);
            this.grBoxBusquedaCliente.TabIndex = 1;
            this.grBoxBusquedaCliente.TabStop = false;
            this.grBoxBusquedaCliente.Text = "Búsqueda de Cliente";
            // 
            // btnRegresar
            // 
            this.btnRegresar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegresar.Image")));
            this.btnRegresar.Location = new System.Drawing.Point(191, 17);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(28, 22);
            this.btnRegresar.TabIndex = 35;
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // txtCedulaRUC
            // 
            this.txtCedulaRUC.BackColor = System.Drawing.Color.Honeydew;
            this.txtCedulaRUC.Location = new System.Drawing.Point(94, 18);
            this.txtCedulaRUC.Name = "txtCedulaRUC";
            this.txtCedulaRUC.Size = new System.Drawing.Size(91, 20);
            this.txtCedulaRUC.TabIndex = 1;
            this.txtCedulaRUC.TextChanged += new System.EventHandler(this.txtCedulaRUC_TextChanged);
            this.txtCedulaRUC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedulaRUC_KeyPress);
            // 
            // lblCedulaRUC
            // 
            this.lblCedulaRUC.AutoSize = true;
            this.lblCedulaRUC.Location = new System.Drawing.Point(10, 22);
            this.lblCedulaRUC.Name = "lblCedulaRUC";
            this.lblCedulaRUC.Size = new System.Drawing.Size(78, 13);
            this.lblCedulaRUC.TabIndex = 13;
            this.lblCedulaRUC.Text = "Cédula o RUC:";
            // 
            // PClienteConsultar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(584, 295);
            this.Controls.Add(this.grBoxBusquedaCliente);
            this.Controls.Add(this.grBoxListaClientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PClienteConsultar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Cliente";
            this.Load += new System.EventHandler(this.PClienteConsultar_Load);
            this.grBoxListaClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataClientes)).EndInit();
            this.grBoxBusquedaCliente.ResumeLayout(false);
            this.grBoxBusquedaCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grBoxListaClientes;
        private System.Windows.Forms.DataGridView dataClientes;
        private System.Windows.Forms.GroupBox grBoxBusquedaCliente;
        private System.Windows.Forms.TextBox txtCedulaRUC;
        private System.Windows.Forms.Label lblCedulaRUC;
        private System.Windows.Forms.Button btnRegresar;
    }
}