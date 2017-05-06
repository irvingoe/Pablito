namespace Pablito
{
    partial class Movimientos
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
            this.txtEnlace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.brnGuardar = new System.Windows.Forms.Button();
            this.lblDyn = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.txtAlmacen = new System.Windows.Forms.TextBox();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMovimiento = new System.Windows.Forms.ComboBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEnlace
            // 
            this.txtEnlace.Location = new System.Drawing.Point(289, 10);
            this.txtEnlace.MaxLength = 6;
            this.txtEnlace.Name = "txtEnlace";
            this.txtEnlace.Size = new System.Drawing.Size(121, 20);
            this.txtEnlace.TabIndex = 3;
            this.txtEnlace.TextChanged += new System.EventHandler(this.txtEnlace_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "N° Factura";
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvArticulos.Location = new System.Drawing.Point(16, 155);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(394, 150);
            this.dgvArticulos.TabIndex = 4;
            this.dgvArticulos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulos_CellDoubleClick);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(16, 321);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 5;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // brnGuardar
            // 
            this.brnGuardar.Location = new System.Drawing.Point(121, 321);
            this.brnGuardar.Name = "brnGuardar";
            this.brnGuardar.Size = new System.Drawing.Size(75, 23);
            this.brnGuardar.TabIndex = 6;
            this.brnGuardar.Text = "Guardar";
            this.brnGuardar.UseVisualStyleBackColor = true;
            this.brnGuardar.Click += new System.EventHandler(this.brnGuardar_Click);
            // 
            // lblDyn
            // 
            this.lblDyn.AutoSize = true;
            this.lblDyn.Location = new System.Drawing.Point(13, 70);
            this.lblDyn.Name = "lblDyn";
            this.lblDyn.Size = new System.Drawing.Size(56, 13);
            this.lblDyn.TabIndex = 2;
            this.lblDyn.Text = "Proveedor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Almacen";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(75, 67);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(121, 20);
            this.txtProveedor.TabIndex = 3;
            // 
            // txtAlmacen
            // 
            this.txtAlmacen.Location = new System.Drawing.Point(291, 67);
            this.txtAlmacen.Name = "txtAlmacen";
            this.txtAlmacen.Size = new System.Drawing.Size(121, 20);
            this.txtAlmacen.TabIndex = 3;
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.AllowUserToOrderColumns = true;
            this.dgvMovimientos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Location = new System.Drawing.Point(12, 390);
            this.dgvMovimientos.MultiSelect = false;
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMovimientos.Size = new System.Drawing.Size(394, 150);
            this.dgvMovimientos.TabIndex = 4;
            this.dgvMovimientos.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovimientos_CellValidated);
            this.dgvMovimientos.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvMovimientos_CellValidating);
            this.dgvMovimientos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvMovimientos_KeyDown);
            this.dgvMovimientos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvMovimientos_KeyPress);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(100, 119);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(310, 20);
            this.txtBusqueda.TabIndex = 3;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtProveedor_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Busqueda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Movimiento";
            // 
            // cmbMovimiento
            // 
            this.cmbMovimiento.FormattingEnabled = true;
            this.cmbMovimiento.Items.AddRange(new object[] {
            "Compra (C)",
            "Salida (T)"});
            this.cmbMovimiento.Location = new System.Drawing.Point(75, 10);
            this.cmbMovimiento.Name = "cmbMovimiento";
            this.cmbMovimiento.Size = new System.Drawing.Size(121, 21);
            this.cmbMovimiento.TabIndex = 1;
            this.cmbMovimiento.SelectedIndexChanged += new System.EventHandler(this.cmbMovimiento_SelectedIndexChanged);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(13, 361);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(61, 13);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Movimiento";
            // 
            // Movimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 552);
            this.Controls.Add(this.brnGuardar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.dgvMovimientos);
            this.Controls.Add(this.dgvArticulos);
            this.Controls.Add(this.txtAlmacen);
            this.Controls.Add(this.txtEnlace);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.txtProveedor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDyn);
            this.Controls.Add(this.cmbMovimiento);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.label1);
            this.Name = "Movimientos";
            this.Text = "Movimientos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtEnlace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button brnGuardar;
        private System.Windows.Forms.Label lblDyn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.TextBox txtAlmacen;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMovimiento;
        private System.Windows.Forms.Label lblDescripcion;
    }
}