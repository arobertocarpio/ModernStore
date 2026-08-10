namespace ModernStore.Forms
{
    partial class CorteCajaForm
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
            dtpFecha = new DateTimePicker();
            btnGenerar = new Button();
            label3 = new Label();
            dgvVentas = new DataGridView();
            lblCantidadVentas = new Label();
            lblTotalEfectivo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(310, 9);
            label1.Name = "label1";
            label1.Size = new Size(149, 25);
            label1.TabIndex = 0;
            label1.Text = "💰 Corte de caja";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 63);
            label2.Name = "label2";
            label2.Size = new Size(53, 21);
            label2.TabIndex = 1;
            label2.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(71, 63);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 23);
            dtpFecha.TabIndex = 2;
            // 
            // btnGenerar
            // 
            btnGenerar.Font = new Font("Segoe UI", 12F);
            btnGenerar.Location = new Point(713, 63);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(75, 32);
            btnGenerar.TabIndex = 3;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 102);
            label3.Name = "label3";
            label3.Size = new Size(56, 21);
            label3.TabIndex = 4;
            label3.Text = "Ventas";
            // 
            // dgvVentas
            // 
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(12, 126);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.Size = new Size(776, 240);
            dgvVentas.TabIndex = 5;
            // 
            // lblCantidadVentas
            // 
            lblCantidadVentas.AutoSize = true;
            lblCantidadVentas.Font = new Font("Segoe UI", 12F);
            lblCantidadVentas.Location = new Point(12, 382);
            lblCantidadVentas.Name = "lblCantidadVentas";
            lblCantidadVentas.Size = new Size(122, 21);
            lblCantidadVentas.TabIndex = 6;
            lblCantidadVentas.Text = "Cantidad Ventas";
            // 
            // lblTotalEfectivo
            // 
            lblTotalEfectivo.AutoSize = true;
            lblTotalEfectivo.Font = new Font("Segoe UI", 12F);
            lblTotalEfectivo.Location = new Point(638, 382);
            lblTotalEfectivo.Name = "lblTotalEfectivo";
            lblTotalEfectivo.Size = new Size(100, 21);
            lblTotalEfectivo.TabIndex = 7;
            lblTotalEfectivo.Text = "Total Efectivo";
            // 
            // CorteCajaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTotalEfectivo);
            Controls.Add(lblCantidadVentas);
            Controls.Add(dgvVentas);
            Controls.Add(label3);
            Controls.Add(btnGenerar);
            Controls.Add(dtpFecha);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CorteCajaForm";
            Text = "CorteCaja";
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dtpFecha;
        private Button btnGenerar;
        private Label label3;
        private DataGridView dgvVentas;
        private Label lblCantidadVentas;
        private Label lblTotalEfectivo;
    }
}