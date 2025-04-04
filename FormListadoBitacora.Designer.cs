namespace Sistema_Venta
{
    partial class FormListadoBitacora
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbactividad = new System.Windows.Forms.RadioButton();
            this.rbusuario = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.rbfecha = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(512, 242);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bitacora";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(504, 222);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbfecha);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.rbactividad);
            this.groupBox2.Controls.Add(this.rbusuario);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Location = new System.Drawing.Point(13, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 58);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar";
            // 
            // rbactividad
            // 
            this.rbactividad.AutoSize = true;
            this.rbactividad.Location = new System.Drawing.Point(87, 27);
            this.rbactividad.Name = "rbactividad";
            this.rbactividad.Size = new System.Drawing.Size(82, 19);
            this.rbactividad.TabIndex = 1;
            this.rbactividad.TabStop = true;
            this.rbactividad.Text = "Actividad";
            this.rbactividad.UseVisualStyleBackColor = true;
            this.rbactividad.CheckedChanged += new System.EventHandler(this.rbactividad_CheckedChanged);
            // 
            // rbusuario
            // 
            this.rbusuario.AutoSize = true;
            this.rbusuario.Location = new System.Drawing.Point(6, 27);
            this.rbusuario.Name = "rbusuario";
            this.rbusuario.Size = new System.Drawing.Size(75, 19);
            this.rbusuario.TabIndex = 0;
            this.rbusuario.TabStop = true;
            this.rbusuario.Text = "Usuario";
            this.rbusuario.UseVisualStyleBackColor = true;
            this.rbusuario.CheckedChanged += new System.EventHandler(this.rbusuario_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(243, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(261, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(245, 27);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(259, 21);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // rbfecha
            // 
            this.rbfecha.AutoSize = true;
            this.rbfecha.Location = new System.Drawing.Point(175, 27);
            this.rbfecha.Name = "rbfecha";
            this.rbfecha.Size = new System.Drawing.Size(64, 19);
            this.rbfecha.TabIndex = 2;
            this.rbfecha.TabStop = true;
            this.rbfecha.Text = "Fecha";
            this.rbfecha.UseVisualStyleBackColor = true;
            this.rbfecha.CheckedChanged += new System.EventHandler(this.rbfecha_CheckedChanged);
            // 
            // FormListadoBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 330);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormListadoBitacora";
            this.Load += new System.EventHandler(this.FormListadoBitacora_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbactividad;
        private System.Windows.Forms.RadioButton rbusuario;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton rbfecha;
    }
}