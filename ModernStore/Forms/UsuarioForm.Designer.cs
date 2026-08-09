namespace ModernStore.Forms
{
    partial class UsuarioForm
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
            btnGuardar = new Button();
            btnCancelar = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtNombre = new TextBox();
            txtApellidoPaterno = new TextBox();
            txtApellidoMaterno = new TextBox();
            txtNombreUsuario = new TextBox();
            cmbRol = new ComboBox();
            txtContrasena = new TextBox();
            txtConfirmarContrasena = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(108, 25);
            label1.TabIndex = 0;
            label1.Text = "👤  Usuario";
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 12F);
            btnGuardar.Location = new Point(12, 429);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 33);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 12F);
            btnCancelar.Location = new Point(228, 429);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(89, 33);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 49);
            label2.Name = "label2";
            label2.Size = new Size(71, 21);
            label2.TabIndex = 3;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 251);
            label3.Name = "label3";
            label3.Size = new Size(36, 21);
            label3.TabIndex = 4;
            label3.Text = "Rol:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 297);
            label4.Name = "label4";
            label4.Size = new Size(92, 21);
            label4.TabIndex = 5;
            label4.Text = "Contraseña:";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 12F);
            label.Location = new Point(12, 347);
            label.Name = "label";
            label.Size = new Size(167, 21);
            label.TabIndex = 6;
            label.Text = "Confirmar Contraseña:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(12, 203);
            label6.Name = "label6";
            label6.Size = new Size(150, 21);
            label6.TabIndex = 7;
            label6.Text = "Nombre de Usuario:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(12, 149);
            label7.Name = "label7";
            label7.Size = new Size(133, 21);
            label7.TabIndex = 8;
            label7.Text = "Apellido Materno:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(12, 99);
            label8.Name = "label8";
            label8.Size = new Size(127, 21);
            label8.TabIndex = 9;
            label8.Text = "Apellido Paterno:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 73);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(305, 23);
            txtNombre.TabIndex = 10;
            // 
            // txtApellidoPaterno
            // 
            txtApellidoPaterno.Location = new Point(12, 123);
            txtApellidoPaterno.Name = "txtApellidoPaterno";
            txtApellidoPaterno.Size = new Size(305, 23);
            txtApellidoPaterno.TabIndex = 11;
            // 
            // txtApellidoMaterno
            // 
            txtApellidoMaterno.Location = new Point(12, 173);
            txtApellidoMaterno.Name = "txtApellidoMaterno";
            txtApellidoMaterno.Size = new Size(305, 23);
            txtApellidoMaterno.TabIndex = 12;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(12, 225);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(305, 23);
            txtNombreUsuario.TabIndex = 13;
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(12, 271);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(305, 23);
            cmbRol.TabIndex = 14;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(12, 321);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(305, 23);
            txtContrasena.TabIndex = 15;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // txtConfirmarContrasena
            // 
            txtConfirmarContrasena.Location = new Point(12, 371);
            txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            txtConfirmarContrasena.Size = new Size(305, 23);
            txtConfirmarContrasena.TabIndex = 16;
            txtConfirmarContrasena.UseSystemPasswordChar = true;
            // 
            // UsuarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 548);
            Controls.Add(txtConfirmarContrasena);
            Controls.Add(txtContrasena);
            Controls.Add(cmbRol);
            Controls.Add(txtNombreUsuario);
            Controls.Add(txtApellidoMaterno);
            Controls.Add(txtApellidoPaterno);
            Controls.Add(txtNombre);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(label1);
            Name = "UsuarioForm";
            Text = "UsuarioForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtNombre;
        private TextBox txtApellidoPaterno;
        private TextBox txtApellidoMaterno;
        private TextBox txtNombreUsuario;
        private ComboBox cmbRol;
        private TextBox txtContrasena;
        private TextBox txtConfirmarContrasena;
    }
}