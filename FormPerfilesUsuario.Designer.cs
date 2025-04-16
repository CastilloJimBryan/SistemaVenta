namespace Sistema_Venta
{
    partial class FormPerfilesUsuario
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
            this.cbxUsuario = new System.Windows.Forms.ComboBox();
            this.cbxRol = new System.Windows.Forms.ComboBox();
            this.cbxAccion = new System.Windows.Forms.ComboBox();
            this.gpxUsuario = new System.Windows.Forms.GroupBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.gpxRol = new System.Windows.Forms.GroupBox();
            this.btnAgregarRol = new System.Windows.Forms.Button();
            this.gpxAccion = new System.Windows.Forms.GroupBox();
            this.btnAgregarAccion = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.gpxUsuario.SuspendLayout();
            this.gpxRol.SuspendLayout();
            this.gpxAccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxUsuario
            // 
            this.cbxUsuario.FormattingEnabled = true;
            this.cbxUsuario.Location = new System.Drawing.Point(23, 32);
            this.cbxUsuario.Name = "cbxUsuario";
            this.cbxUsuario.Size = new System.Drawing.Size(168, 24);
            this.cbxUsuario.TabIndex = 0;
            // 
            // cbxRol
            // 
            this.cbxRol.FormattingEnabled = true;
            this.cbxRol.Location = new System.Drawing.Point(23, 39);
            this.cbxRol.Name = "cbxRol";
            this.cbxRol.Size = new System.Drawing.Size(168, 24);
            this.cbxRol.TabIndex = 1;
            // 
            // cbxAccion
            // 
            this.cbxAccion.FormattingEnabled = true;
            this.cbxAccion.Location = new System.Drawing.Point(23, 36);
            this.cbxAccion.Name = "cbxAccion";
            this.cbxAccion.Size = new System.Drawing.Size(168, 24);
            this.cbxAccion.TabIndex = 2;
            // 
            // gpxUsuario
            // 
            this.gpxUsuario.Controls.Add(this.btnSeleccionar);
            this.gpxUsuario.Controls.Add(this.cbxUsuario);
            this.gpxUsuario.Location = new System.Drawing.Point(12, 12);
            this.gpxUsuario.Name = "gpxUsuario";
            this.gpxUsuario.Size = new System.Drawing.Size(212, 115);
            this.gpxUsuario.TabIndex = 3;
            this.gpxUsuario.TabStop = false;
            this.gpxUsuario.Text = "Usuario";
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(23, 78);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(168, 31);
            this.btnSeleccionar.TabIndex = 6;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // gpxRol
            // 
            this.gpxRol.Controls.Add(this.btnAgregarRol);
            this.gpxRol.Controls.Add(this.cbxRol);
            this.gpxRol.Location = new System.Drawing.Point(12, 148);
            this.gpxRol.Name = "gpxRol";
            this.gpxRol.Size = new System.Drawing.Size(212, 115);
            this.gpxRol.TabIndex = 4;
            this.gpxRol.TabStop = false;
            this.gpxRol.Text = "Rol";
            // 
            // btnAgregarRol
            // 
            this.btnAgregarRol.Location = new System.Drawing.Point(23, 78);
            this.btnAgregarRol.Name = "btnAgregarRol";
            this.btnAgregarRol.Size = new System.Drawing.Size(168, 31);
            this.btnAgregarRol.TabIndex = 6;
            this.btnAgregarRol.Text = "Agregar";
            this.btnAgregarRol.UseVisualStyleBackColor = true;
            this.btnAgregarRol.Click += new System.EventHandler(this.btnAgregarRol_Click);
            // 
            // gpxAccion
            // 
            this.gpxAccion.Controls.Add(this.btnAgregarAccion);
            this.gpxAccion.Controls.Add(this.cbxAccion);
            this.gpxAccion.Location = new System.Drawing.Point(12, 285);
            this.gpxAccion.Name = "gpxAccion";
            this.gpxAccion.Size = new System.Drawing.Size(212, 115);
            this.gpxAccion.TabIndex = 5;
            this.gpxAccion.TabStop = false;
            this.gpxAccion.Text = "Accion";
            // 
            // btnAgregarAccion
            // 
            this.btnAgregarAccion.Location = new System.Drawing.Point(23, 78);
            this.btnAgregarAccion.Name = "btnAgregarAccion";
            this.btnAgregarAccion.Size = new System.Drawing.Size(168, 31);
            this.btnAgregarAccion.TabIndex = 6;
            this.btnAgregarAccion.Text = "Agregar";
            this.btnAgregarAccion.UseVisualStyleBackColor = true;
            this.btnAgregarAccion.Click += new System.EventHandler(this.btnAgregarAccion_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(230, 363);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(216, 31);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(230, 309);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(216, 43);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(230, 20);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(216, 289);
            this.treeView1.TabIndex = 9;
            // 
            // FormPerfilesUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 412);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.gpxAccion);
            this.Controls.Add(this.gpxRol);
            this.Controls.Add(this.gpxUsuario);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormPerfilesUsuario";
            this.Text = "Administrar Perfil de Usuario";
            this.Load += new System.EventHandler(this.FormPerfilesUsuario_Load);
            this.gpxUsuario.ResumeLayout(false);
            this.gpxRol.ResumeLayout(false);
            this.gpxAccion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxUsuario;
        private System.Windows.Forms.ComboBox cbxRol;
        private System.Windows.Forms.ComboBox cbxAccion;
        private System.Windows.Forms.GroupBox gpxUsuario;
        private System.Windows.Forms.GroupBox gpxRol;
        private System.Windows.Forms.GroupBox gpxAccion;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnAgregarRol;
        private System.Windows.Forms.Button btnAgregarAccion;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TreeView treeView1;
    }
}