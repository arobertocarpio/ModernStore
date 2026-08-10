namespace ModernStore.Forms
{
    partial class ReportesForm
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
            dtpFechaInicio = new DateTimePicker();
            btnGenerar = new Button();
            dgvReporte = new DataGridView();
            lblTotalVentas = new Label();
            lblTotalVendido = new Label();
            btnExportarPDF = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(296, 9);
            label1.Name = "label1";
            label1.Size = new Size(180, 25);
            label1.TabIndex = 0;
            label1.Text = "📊 Reporte Semanal";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 64);
            label2.Name = "label2";
            label2.Size = new Size(94, 21);
            label2.TabIndex = 1;
            label2.Text = "Fecha Inicio:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Location = new Point(12, 88);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(232, 23);
            dtpFechaInicio.TabIndex = 2;
            // 
            // btnGenerar
            // 
            btnGenerar.Font = new Font("Segoe UI", 12F);
            btnGenerar.Location = new Point(644, 80);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(144, 31);
            btnGenerar.TabIndex = 3;
            btnGenerar.Text = "Generar Reporte";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // dgvReporte
            // 
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(12, 117);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.RowTemplate.ReadOnly = true;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.Size = new Size(776, 265);
            dgvReporte.TabIndex = 4;
            // 
            // lblTotalVentas
            // 
            lblTotalVentas.AutoSize = true;
            lblTotalVentas.Font = new Font("Segoe UI", 12F);
            lblTotalVentas.Location = new Point(12, 395);
            lblTotalVentas.Name = "lblTotalVentas";
            lblTotalVentas.Size = new Size(45, 21);
            lblTotalVentas.TabIndex = 5;
            lblTotalVentas.Text = "Total:";
            // 
            // lblTotalVendido
            // 
            lblTotalVendido.AutoSize = true;
            lblTotalVendido.Font = new Font("Segoe UI", 12F);
            lblTotalVendido.Location = new Point(644, 395);
            lblTotalVendido.Name = "lblTotalVendido";
            lblTotalVendido.Size = new Size(106, 21);
            lblTotalVendido.TabIndex = 6;
            lblTotalVendido.Text = "Total Vendido:";
            // 
            // btnExportarPDF
            // 
            btnExportarPDF.Font = new Font("Segoe UI", 12F);
            btnExportarPDF.Location = new Point(296, 395);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(180, 32);
            btnExportarPDF.TabIndex = 7;
            btnExportarPDF.Text = "Exportar PDF";
            btnExportarPDF.UseVisualStyleBackColor = true;
            btnExportarPDF.Click += btnExportarPDF_Click;
            // 
            // ReportesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExportarPDF);
            Controls.Add(lblTotalVendido);
            Controls.Add(lblTotalVentas);
            Controls.Add(dgvReporte);
            Controls.Add(btnGenerar);
            Controls.Add(dtpFechaInicio);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ReportesForm";
            Text = "ReportesForm";
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dtpFechaInicio;
        private Button btnGenerar;
        private DataGridView dgvReporte;
        private Label lblTotalVentas;
        private Label lblTotalVendido;
        private Button btnExportarPDF;
    }
}