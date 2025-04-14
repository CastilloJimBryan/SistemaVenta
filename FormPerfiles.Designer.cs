namespace Sistema_Venta
{
    partial class FormPerfiles
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
            this.gpxRol = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gpxAccion = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblEscribirRol = new System.Windows.Forms.Label();
            this.lblEscribirAccion = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnAgrega = new System.Windows.Forms.Button();
            this.gpxRol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gpxAccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // gpxRol
            // 
            this.gpxRol.Controls.Add(this.dataGridView1);
            this.gpxRol.Location = new System.Drawing.Point(48, 39);
            this.gpxRol.Name = "gpxRol";
            this.gpxRol.Size = new System.Drawing.Size(172, 258);
            this.gpxRol.TabIndex = 0;
            this.gpxRol.TabStop = false;
            this.gpxRol.Text = "Rol";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(166, 237);
            this.dataGridView1.TabIndex = 2;
            // 
            // gpxAccion
            // 
            this.gpxAccion.Controls.Add(this.dataGridView2);
            this.gpxAccion.Location = new System.Drawing.Point(368, 39);
            this.gpxAccion.Name = "gpxAccion";
            this.gpxAccion.Size = new System.Drawing.Size(160, 258);
            this.gpxAccion.TabIndex = 1;
            this.gpxAccion.TabStop = false;
            this.gpxAccion.Text = "Accion";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 18);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(154, 237);
            this.dataGridView2.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 325);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(71, 49);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(106, 303);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 22);
            this.textBox1.TabIndex = 3;
            // 
            // lblEscribirRol
            // 
            this.lblEscribirRol.AutoSize = true;
            this.lblEscribirRol.Location = new System.Drawing.Point(12, 306);
            this.lblEscribirRol.Name = "lblEscribirRol";
            this.lblEscribirRol.Size = new System.Drawing.Size(88, 16);
            this.lblEscribirRol.TabIndex = 4;
            this.lblEscribirRol.Text = "Escribir Rol";
            // 
            // lblEscribirAccion
            // 
            this.lblEscribirAccion.AutoSize = true;
            this.lblEscribirAccion.Location = new System.Drawing.Point(303, 306);
            this.lblEscribirAccion.Name = "lblEscribirAccion";
            this.lblEscribirAccion.Size = new System.Drawing.Size(107, 16);
            this.lblEscribirAccion.TabIndex = 5;
            this.lblEscribirAccion.Text = "EscribirAccion";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(416, 303);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 22);
            this.textBox2.TabIndex = 6;
            // 
            // btnAgrega
            // 
            this.btnAgrega.Location = new System.Drawing.Point(306, 325);
            this.btnAgrega.Name = "btnAgrega";
            this.btnAgrega.Size = new System.Drawing.Size(75, 49);
            this.btnAgrega.TabIndex = 7;
            this.btnAgrega.Text = "Agregar";
            this.btnAgrega.UseVisualStyleBackColor = true;
            this.btnAgrega.Click += new System.EventHandler(this.btnAgrega_Click);
            // 
            // FormPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 386);
            this.Controls.Add(this.btnAgrega);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblEscribirAccion);
            this.Controls.Add(this.lblEscribirRol);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.gpxAccion);
            this.Controls.Add(this.gpxRol);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormPerfiles";
            this.Text = "Perfiles";
            this.Load += new System.EventHandler(this.FormPerfiles_Load);
            this.gpxRol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gpxAccion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpxRol;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox gpxAccion;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblEscribirRol;
        private System.Windows.Forms.Label lblEscribirAccion;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnAgrega;
    }
}