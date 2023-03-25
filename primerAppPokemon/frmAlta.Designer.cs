namespace primerAppPokemon
{
    partial class frmAlta
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
            this.labelNumero = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.textBoxNumero = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxDescrip = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelTipo = new System.Windows.Forms.Label();
            this.labelDebilidad = new System.Windows.Forms.Label();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.comboDebilidad = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Location = new System.Drawing.Point(32, 56);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(63, 20);
            this.labelNumero.TabIndex = 0;
            this.labelNumero.Text = "Numero";
            this.labelNumero.Click += new System.EventHandler(this.labelNumero_Click);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(32, 107);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(64, 20);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Text = "Nombre";
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Location = new System.Drawing.Point(32, 159);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(87, 20);
            this.labelDescripcion.TabIndex = 2;
            this.labelDescripcion.Text = "Descripcion";
            // 
            // textBoxNumero
            // 
            this.textBoxNumero.Location = new System.Drawing.Point(156, 50);
            this.textBoxNumero.Name = "textBoxNumero";
            this.textBoxNumero.Size = new System.Drawing.Size(168, 26);
            this.textBoxNumero.TabIndex = 3;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(156, 101);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(168, 26);
            this.textBoxNombre.TabIndex = 4;
            // 
            // textBoxDescrip
            // 
            this.textBoxDescrip.Location = new System.Drawing.Point(156, 156);
            this.textBoxDescrip.Name = "textBoxDescrip";
            this.textBoxDescrip.Size = new System.Drawing.Size(168, 26);
            this.textBoxDescrip.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(32, 340);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(111, 43);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(207, 340);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 45);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Location = new System.Drawing.Point(32, 215);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(39, 20);
            this.labelTipo.TabIndex = 8;
            this.labelTipo.Text = "Tipo";
            // 
            // labelDebilidad
            // 
            this.labelDebilidad.AutoSize = true;
            this.labelDebilidad.Location = new System.Drawing.Point(32, 263);
            this.labelDebilidad.Name = "labelDebilidad";
            this.labelDebilidad.Size = new System.Drawing.Size(75, 20);
            this.labelDebilidad.TabIndex = 9;
            this.labelDebilidad.Text = "Debilidad";
            // 
            // comboTipo
            // 
            this.comboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Location = new System.Drawing.Point(156, 215);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(168, 27);
            this.comboTipo.TabIndex = 10;
            // 
            // comboDebilidad
            // 
            this.comboDebilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDebilidad.FormattingEnabled = true;
            this.comboDebilidad.Location = new System.Drawing.Point(156, 263);
            this.comboDebilidad.Name = "comboDebilidad";
            this.comboDebilidad.Size = new System.Drawing.Size(168, 27);
            this.comboDebilidad.TabIndex = 11;
            this.comboDebilidad.SelectedIndexChanged += new System.EventHandler(this.comboDebilidad_SelectedIndexChanged);
            // 
            // frmAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 420);
            this.Controls.Add(this.comboDebilidad);
            this.Controls.Add(this.comboTipo);
            this.Controls.Add(this.labelDebilidad);
            this.Controls.Add(this.labelTipo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.textBoxDescrip);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.textBoxNumero);
            this.Controls.Add(this.labelDescripcion);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelNumero);
            this.Name = "frmAlta";
            this.Text = "frmAlta";
            this.Load += new System.EventHandler(this.frmAlta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelNumero;
        private Label labelNombre;
        private Label labelDescripcion;
        private TextBox textBoxNumero;
        private TextBox textBoxNombre;
        private TextBox textBoxDescrip;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label labelTipo;
        private Label labelDebilidad;
        private ComboBox comboTipo;
        private ComboBox comboDebilidad;
    }
}