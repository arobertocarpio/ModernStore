namespace ModernStore.Forms
{
    partial class POSForm
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
            txtBuscar = new TextBox();
            dgvProductos = new DataGridView();
            btnAgregar = new Button();
            label1 = new Label();
            dgvCarrito = new DataGridView();
            label2 = new Label();
            lblTotal = new Label();
            btnCobrar = new Button();
            label3 = new Label();
            label4 = new Label();
            btnQuitar = new Button();
            cmbCliente = new ComboBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(36, 38);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(120, 23);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(36, 99);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(710, 108);
            dgvProductos.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(181, 38);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 20);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 3;
            label1.Text = "Buscar:";
            // 
            // dgvCarrito
            // 
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(36, 248);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.Size = new Size(710, 150);
            dgvCarrito.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 418);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 5;
            label2.Text = "Total:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(78, 418);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(37, 15);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "$ 0.00";
            // 
            // btnCobrar
            // 
            btnCobrar.Location = new Point(36, 450);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(75, 23);
            btnCobrar.TabIndex = 7;
            btnCobrar.Text = "Cobrar";
            btnCobrar.UseVisualStyleBackColor = true;
            btnCobrar.Click += btnCobrar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 81);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 8;
            label3.Text = "PRODUCTOS";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 221);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 9;
            label4.Text = "CARRITO";
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(181, 217);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(119, 23);
            btnQuitar.TabIndex = 10;
            btnQuitar.Text = "Quitar Producto";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(303, 38);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(178, 23);
            cmbCliente.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(303, 14);
            label5.Name = "label5";
            label5.Size = new Size(61, 21);
            label5.TabIndex = 12;
            label5.Text = "Cliente:";
            // 
            // POSForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 503);
            Controls.Add(label5);
            Controls.Add(cmbCliente);
            Controls.Add(btnQuitar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnCobrar);
            Controls.Add(lblTotal);
            Controls.Add(label2);
            Controls.Add(dgvCarrito);
            Controls.Add(label1);
            Controls.Add(btnAgregar);
            Controls.Add(dgvProductos);
            Controls.Add(txtBuscar);
            Name = "POSForm";
            Text = "POSForm";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBuscar;
        private DataGridView dgvProductos;
        private Button btnAgregar;
        private Label label1;
        private DataGridView dgvCarrito;
        private Label label2;
        private Label lblTotal;
        private Button btnCobrar;
        private Label label3;
        private Label label4;
        private Button btnQuitar;
        private ComboBox cmbCliente;
        private Label label5;
    }
}