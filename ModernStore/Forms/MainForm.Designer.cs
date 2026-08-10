namespace ModernStore.Forms
{
    partial class MainForm
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
            btnPOS = new Button();
            btnProductos = new Button();
            btnCategorias = new Button();
            btnClientes = new Button();
            btnUsuarios = new Button();
            btnVentas = new Button();
            btnCerrarSesion = new Button();
            label1 = new Label();
            lblUsuario = new Label();
            btnProveedores = new Button();
            SuspendLayout();
            // 
            // btnPOS
            // 
            btnPOS.Font = new Font("Segoe UI", 12F);
            btnPOS.Location = new Point(60, 149);
            btnPOS.Name = "btnPOS";
            btnPOS.Size = new Size(173, 32);
            btnPOS.TabIndex = 0;
            btnPOS.Text = "\U0001f6d2  Punto de Venta";
            btnPOS.UseVisualStyleBackColor = true;
            btnPOS.Click += btnPOS_Click;
            // 
            // btnProductos
            // 
            btnProductos.Font = new Font("Segoe UI", 12F);
            btnProductos.Location = new Point(239, 149);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(173, 32);
            btnProductos.TabIndex = 1;
            btnProductos.Text = "📦  Productos";
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnCategorias
            // 
            btnCategorias.Font = new Font("Segoe UI", 12F);
            btnCategorias.Location = new Point(60, 213);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(173, 32);
            btnCategorias.TabIndex = 2;
            btnCategorias.Text = "🏷️  Categorías";
            btnCategorias.UseVisualStyleBackColor = true;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // btnClientes
            // 
            btnClientes.Font = new Font("Segoe UI", 12F);
            btnClientes.Location = new Point(239, 213);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(173, 32);
            btnClientes.TabIndex = 3;
            btnClientes.Text = "👥  Clientes\n";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Font = new Font("Segoe UI", 12F);
            btnUsuarios.Location = new Point(60, 268);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(173, 32);
            btnUsuarios.TabIndex = 4;
            btnUsuarios.Text = "👤  Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnVentas
            // 
            btnVentas.Font = new Font("Segoe UI", 12F);
            btnVentas.Location = new Point(239, 268);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(173, 32);
            btnVentas.TabIndex = 5;
            btnVentas.Text = "📊  Ventas / Reportes";
            btnVentas.UseVisualStyleBackColor = true;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Font = new Font("Segoe UI", 12F);
            btnCerrarSesion.Location = new Point(60, 406);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(173, 32);
            btnCerrarSesion.TabIndex = 6;
            btnCerrarSesion.Text = "🚪  Cerrar sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(60, 25);
            label1.Name = "label1";
            label1.Size = new Size(201, 25);
            label1.TabIndex = 7;
            label1.Text = "🏪 Tienda La Moderna";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 14F);
            lblUsuario.Location = new Point(239, 82);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(118, 25);
            lblUsuario.TabIndex = 8;
            lblUsuario.Text = "Usuario | Rol";
            // 
            // btnProveedores
            // 
            btnProveedores.Font = new Font("Segoe UI", 12F);
            btnProveedores.Location = new Point(60, 317);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Size = new Size(173, 32);
            btnProveedores.TabIndex = 9;
            btnProveedores.Text = "🚚 Proveedores";
            btnProveedores.UseVisualStyleBackColor = true;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 450);
            Controls.Add(btnProveedores);
            Controls.Add(lblUsuario);
            Controls.Add(label1);
            Controls.Add(btnCerrarSesion);
            Controls.Add(btnVentas);
            Controls.Add(btnUsuarios);
            Controls.Add(btnClientes);
            Controls.Add(btnCategorias);
            Controls.Add(btnProductos);
            Controls.Add(btnPOS);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPOS;
        private Button btnProductos;
        private Button btnCategorias;
        private Button btnClientes;
        private Button btnUsuarios;
        private Button btnVentas;
        private Button btnCerrarSesion;
        private Label label1;
        private Label lblUsuario;
        private Button btnProveedores;
    }
}