namespace ModernStore.Forms
{
    partial class CategoriaForm
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
            btnGuardar = new Button();
            brnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(125, 25);
            label1.TabIndex = 0;
            label1.Text = "🏷️  Categoría";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 140);
            label2.Name = "label2";
            label2.Size = new Size(71, 21);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 176);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(268, 23);
            txtNombre.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 12F);
            btnGuardar.Location = new Point(12, 356);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 33);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // brnCancelar
            // 
            brnCancelar.Font = new Font("Segoe UI", 12F);
            brnCancelar.Location = new Point(197, 356);
            brnCancelar.Name = "brnCancelar";
            brnCancelar.Size = new Size(83, 33);
            brnCancelar.TabIndex = 4;
            brnCancelar.Text = "Cancelar";
            brnCancelar.UseVisualStyleBackColor = true;
            // 
            // CategoriaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 450);
            Controls.Add(brnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CategoriaForm";
            Text = "CategoriasForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNombre;
        private Button btnGuardar;
        private Button brnCancelar;
    }
}