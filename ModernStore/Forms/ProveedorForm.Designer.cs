namespace ModernStore.Forms
{
    partial class ProveedorForm
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
            label3 = new Label();
            label4 = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            txtNombre = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(185, 25);
            label1.TabIndex = 0;
            label1.Text = "🚚 Nuevo Proveedor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 49);
            label2.Name = "label2";
            label2.Size = new Size(71, 21);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 99);
            label3.Name = "label3";
            label3.Size = new Size(71, 21);
            label3.TabIndex = 2;
            label3.Text = "Telefono:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 160);
            label4.Name = "label4";
            label4.Size = new Size(61, 21);
            label4.TabIndex = 3;
            label4.Text = "Correo:";
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 12F);
            btnGuardar.Location = new Point(12, 351);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 32);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 12F);
            btnCancelar.Location = new Point(222, 353);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(84, 30);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 73);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(294, 23);
            txtNombre.TabIndex = 6;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(12, 123);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(294, 23);
            txtTelefono.TabIndex = 7;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(12, 184);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(294, 23);
            txtCorreo.TabIndex = 8;
            // 
            // ProveedorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 450);
            Controls.Add(txtCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(txtNombre);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ProveedorForm";
            Text = "ProveedorForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnGuardar;
        private Button btnCancelar;
        private TextBox txtNombre;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
    }
}