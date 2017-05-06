namespace Pablito
{
    partial class Ultron
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ultron));
            this.label1 = new System.Windows.Forms.Label();
            this.archivoOrigenRuta = new System.Windows.Forms.TextBox();
            this.archivoDestinoRuta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Go = new System.Windows.Forms.Button();
            this.textFiltro = new System.Windows.Forms.TextBox();
            this.Filtro = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Farmacia = new System.Windows.Forms.Label();
            this.textEncabezado = new System.Windows.Forms.TextBox();
            this.Nuevo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textFiltro2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Nery = new System.Windows.Forms.Button();
            this.Helen = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Archivo Origen";
            // 
            // archivoOrigenRuta
            // 
            this.archivoOrigenRuta.Location = new System.Drawing.Point(95, 34);
            this.archivoOrigenRuta.Name = "archivoOrigenRuta";
            this.archivoOrigenRuta.Size = new System.Drawing.Size(312, 20);
            this.archivoOrigenRuta.TabIndex = 1;
            this.archivoOrigenRuta.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            this.archivoOrigenRuta.TextChanged += new System.EventHandler(this.archivoOrigenRuta_TextChanged);
            // 
            // archivoDestinoRuta
            // 
            this.archivoDestinoRuta.Location = new System.Drawing.Point(95, 153);
            this.archivoDestinoRuta.Name = "archivoDestinoRuta";
            this.archivoDestinoRuta.Size = new System.Drawing.Size(312, 20);
            this.archivoDestinoRuta.TabIndex = 10;
            this.archivoDestinoRuta.Click += new System.EventHandler(this.minombreClick);
            this.archivoDestinoRuta.TextChanged += new System.EventHandler(this.archivoDestinoRuta_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Destino";
            // 
            // Go
            // 
            this.Go.Location = new System.Drawing.Point(18, 205);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(75, 23);
            this.Go.TabIndex = 4;
            this.Go.Text = "Go";
            this.Go.UseVisualStyleBackColor = true;
            this.Go.Click += new System.EventHandler(this.Go_Click);
            // 
            // textFiltro
            // 
            this.textFiltro.Location = new System.Drawing.Point(95, 69);
            this.textFiltro.Name = "textFiltro";
            this.textFiltro.Size = new System.Drawing.Size(98, 20);
            this.textFiltro.TabIndex = 2;
            this.textFiltro.TextChanged += new System.EventHandler(this.textFiltro_TextChanged);
            // 
            // Filtro
            // 
            this.Filtro.AutoSize = true;
            this.Filtro.Location = new System.Drawing.Point(15, 75);
            this.Filtro.Name = "Filtro";
            this.Filtro.Size = new System.Drawing.Size(29, 13);
            this.Filtro.TabIndex = 6;
            this.Filtro.Text = "Filtro";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Farmacia
            // 
            this.Farmacia.AutoSize = true;
            this.Farmacia.Location = new System.Drawing.Point(15, 116);
            this.Farmacia.Name = "Farmacia";
            this.Farmacia.Size = new System.Drawing.Size(50, 13);
            this.Farmacia.TabIndex = 9;
            this.Farmacia.Text = "Farmacia";
            // 
            // textEncabezado
            // 
            this.textEncabezado.Location = new System.Drawing.Point(95, 110);
            this.textEncabezado.Name = "textEncabezado";
            this.textEncabezado.Size = new System.Drawing.Size(312, 20);
            this.textEncabezado.TabIndex = 3;
            // 
            // Nuevo
            // 
            this.Nuevo.Location = new System.Drawing.Point(118, 205);
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Size = new System.Drawing.Size(75, 23);
            this.Nuevo.TabIndex = 5;
            this.Nuevo.Text = "Nuevo";
            this.Nuevo.UseVisualStyleBackColor = true;
            this.Nuevo.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Filtro2";
            // 
            // textFiltro2
            // 
            this.textFiltro2.Location = new System.Drawing.Point(274, 72);
            this.textFiltro2.Name = "textFiltro2";
            this.textFiltro2.Size = new System.Drawing.Size(98, 20);
            this.textFiltro2.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Helen);
            this.groupBox1.Controls.Add(this.Nery);
            this.groupBox1.Location = new System.Drawing.Point(30, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inventario";
            // 
            // Nery
            // 
            this.Nery.Location = new System.Drawing.Point(113, 28);
            this.Nery.Name = "Nery";
            this.Nery.Size = new System.Drawing.Size(75, 23);
            this.Nery.TabIndex = 14;
            this.Nery.Text = "Nery";
            this.Nery.UseVisualStyleBackColor = true;
            this.Nery.Click += new System.EventHandler(this.button3_Click);
            // 
            // Helen
            // 
            this.Helen.Location = new System.Drawing.Point(21, 28);
            this.Helen.Name = "Helen";
            this.Helen.Size = new System.Drawing.Size(75, 23);
            this.Helen.TabIndex = 13;
            this.Helen.Text = "Helen";
            this.Helen.UseVisualStyleBackColor = true;
            this.Helen.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(44, 256);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 102);
            this.panel1.TabIndex = 15;
            // 
            // Ultron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 377);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textFiltro2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Nuevo);
            this.Controls.Add(this.Farmacia);
            this.Controls.Add(this.textEncabezado);
            this.Controls.Add(this.Filtro);
            this.Controls.Add(this.textFiltro);
            this.Controls.Add(this.Go);
            this.Controls.Add(this.archivoDestinoRuta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.archivoOrigenRuta);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ultron";
            this.Text = "Inventario";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox archivoOrigenRuta;
        private System.Windows.Forms.TextBox archivoDestinoRuta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Go;
        private System.Windows.Forms.TextBox textFiltro;
        private System.Windows.Forms.Label Filtro;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label Farmacia;
        private System.Windows.Forms.TextBox textEncabezado;
        private System.Windows.Forms.Button Nuevo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textFiltro2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Helen;
        private System.Windows.Forms.Button Nery;
        private System.Windows.Forms.Panel panel1;
    }
}