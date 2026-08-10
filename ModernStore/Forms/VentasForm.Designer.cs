namespace ModernStore.Forms
{
    partial class VentasForm
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
            txtBuscar = new TextBox();
            dgvVentas = new DataGridView();
            btnVerDetalle = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(189, 25);
            label1.TabIndex = 0;
            label1.Text = "📊  Ventas / Reportes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(59, 21);
            label2.TabIndex = 1;
            label2.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(77, 55);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(421, 23);
            txtBuscar.TabIndex = 2;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dgvVentas
            // 
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(12, 84);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.Size = new Size(776, 302);
            dgvVentas.TabIndex = 3;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Font = new Font("Segoe UI", 12F);
            btnVerDetalle.Location = new Point(325, 392);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(143, 30);
            btnVerDetalle.TabIndex = 4;
            btnVerDetalle.Text = "Ver Detalle";
            btnVerDetalle.UseVisualStyleBackColor = true;
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // VentasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnVerDetalle);
            Controls.Add(dgvVentas);
            Controls.Add(txtBuscar);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "VentasForm";
            Text = "VentasForm";
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtBuscar;
        private DataGridView dgvVentas;
        private Button btnVerDetalle;
    }
}