namespace ModernStore.Forms
{
    partial class ProductoForm
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
            label1 = new Label();
            label2 = new Label();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            label3 = new Label();
            label4 = new Label();
            cmbCategoria = new ComboBox();
            label5 = new Label();
            nudPrecio = new NumericUpDown();
            nudStock = new NumericUpDown();
            label6 = new Label();
            label7 = new Label();
            dtpFechaCaducidad = new DateTimePicker();
            chkSinCaducidad = new CheckBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            label8 = new Label();
            cmbProveedores = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(115, 25);
            label1.TabIndex = 0;
            label1.Text = "📦 Producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(0, 35);
            label2.Name = "label2";
            label2.Size = new Size(71, 21);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(0, 59);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(332, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(0, 109);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(332, 23);
            txtDescripcion.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(0, 85);
            label3.Name = "label3";
            label3.Size = new Size(94, 21);
            label3.TabIndex = 4;
            label3.Text = "Descripcion:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(0, 135);
            label4.Name = "label4";
            label4.Size = new Size(80, 21);
            label4.TabIndex = 5;
            label4.Text = "Categoria:";
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(0, 159);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(332, 23);
            cmbCategoria.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(0, 185);
            label5.Name = "label5";
            label5.Size = new Size(56, 21);
            label5.TabIndex = 7;
            label5.Text = "Precio:";
            // 
            // nudPrecio
            // 
            nudPrecio.Location = new Point(0, 209);
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(332, 23);
            nudPrecio.TabIndex = 8;
            // 
            // nudStock
            // 
            nudStock.Location = new Point(0, 259);
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(332, 23);
            nudStock.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(0, 235);
            label6.Name = "label6";
            label6.Size = new Size(50, 21);
            label6.TabIndex = 10;
            label6.Text = "Stock:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(0, 285);
            label7.Name = "label7";
            label7.Size = new Size(153, 21);
            label7.TabIndex = 11;
            label7.Text = "Fecha De Caducidad:";
            // 
            // dtpFechaCaducidad
            // 
            dtpFechaCaducidad.Location = new Point(0, 309);
            dtpFechaCaducidad.Name = "dtpFechaCaducidad";
            dtpFechaCaducidad.Size = new Size(332, 23);
            dtpFechaCaducidad.TabIndex = 12;
            // 
            // chkSinCaducidad
            // 
            chkSinCaducidad.AutoSize = true;
            chkSinCaducidad.Font = new Font("Segoe UI", 12F);
            chkSinCaducidad.Location = new Point(5, 388);
            chkSinCaducidad.Name = "chkSinCaducidad";
            chkSinCaducidad.Size = new Size(193, 25);
            chkSinCaducidad.TabIndex = 13;
            chkSinCaducidad.Text = "Sin Fecha de Caducidad";
            chkSinCaducidad.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 12F);
            btnGuardar.Location = new Point(5, 419);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 29);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 12F);
            btnCancelar.Location = new Point(247, 418);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 30);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(0, 335);
            label8.Name = "label8";
            label8.Size = new Size(100, 21);
            label8.TabIndex = 16;
            label8.Text = "Proveedores:";
            // 
            // cmbProveedores
            // 
            cmbProveedores.FormattingEnabled = true;
            cmbProveedores.Location = new Point(0, 359);
            cmbProveedores.Name = "cmbProveedores";
            cmbProveedores.Size = new Size(332, 23);
            cmbProveedores.TabIndex = 17;
            // 
            // ProductoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(341, 450);
            Controls.Add(cmbProveedores);
            Controls.Add(label8);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(chkSinCaducidad);
            Controls.Add(dtpFechaCaducidad);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(nudStock);
            Controls.Add(nudPrecio);
            Controls.Add(label5);
            Controls.Add(cmbCategoria);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ProductoForm";
            Text = "ProductoForm";
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private Label label3;
        private Label label4;
        private ComboBox cmbCategoria;
        private Label label5;
        private NumericUpDown nudPrecio;
        private NumericUpDown nudStock;
        private Label label6;
        private Label label7;
        private DateTimePicker dtpFechaCaducidad;
        private CheckBox chkSinCaducidad;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label label8;
        private ComboBox cmbProveedores;
    }
}