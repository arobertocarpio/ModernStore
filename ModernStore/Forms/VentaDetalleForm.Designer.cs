namespace ModernStore.Forms
{
    partial class VentaDetalleForm
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
            lblVenta = new Label();
            lblFecha = new Label();
            lblUsuario = new Label();
            lblCliente = new Label();
            dgvDetalle = new DataGridView();
            label4 = new Label();
            lblTotal = new Label();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(306, 9);
            label1.Name = "label1";
            label1.Size = new Size(181, 25);
            label1.TabIndex = 0;
            label1.Text = "📊  Detalle de Venta";
            // 
            // lblVenta
            // 
            lblVenta.AutoSize = true;
            lblVenta.Font = new Font("Segoe UI", 12F);
            lblVenta.Location = new Point(12, 75);
            lblVenta.Name = "lblVenta";
            lblVenta.Size = new Size(49, 21);
            lblVenta.TabIndex = 1;
            lblVenta.Text = "Venta";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 12F);
            lblFecha.Location = new Point(575, 75);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 21);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 12F);
            lblUsuario.Location = new Point(12, 120);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(64, 21);
            lblUsuario.TabIndex = 4;
            lblUsuario.Text = "Usuario";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 12F);
            lblCliente.Location = new Point(12, 150);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(58, 21);
            lblCliente.TabIndex = 6;
            lblCliente.Text = "Cliente";
            // 
            // dgvDetalle
            // 
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Location = new Point(12, 183);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.Size = new Size(776, 206);
            dgvDetalle.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(575, 403);
            label4.Name = "label4";
            label4.Size = new Size(56, 21);
            label4.TabIndex = 8;
            label4.Text = "TOTAL:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F);
            lblTotal.Location = new Point(637, 403);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(42, 21);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "Total";
            // 
            // btnCerrar
            // 
            btnCerrar.Font = new Font("Segoe UI", 12F);
            btnCerrar.Location = new Point(12, 398);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 30);
            btnCerrar.TabIndex = 10;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // VentaDetalleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 520);
            Controls.Add(btnCerrar);
            Controls.Add(lblTotal);
            Controls.Add(label4);
            Controls.Add(dgvDetalle);
            Controls.Add(lblCliente);
            Controls.Add(lblUsuario);
            Controls.Add(lblFecha);
            Controls.Add(lblVenta);
            Controls.Add(label1);
            Name = "VentaDetalleForm";
            Text = "VentalDetalleForm";
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblVenta;
        private Label lblFecha;
        private Label lblUsuario;
        private Label lblCliente;
        private DataGridView dgvDetalle;
        private Label label4;
        private Label lblTotal;
        private Button btnCerrar;
    }
}