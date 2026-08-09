using ModernStore.Models;
using ModernStore.Repositories;

namespace ModernStore.Forms
{
    public partial class ProductoForm : Form
    {
        private readonly ProductoRepository productoRepository;
        private readonly CategoriaRepository categoriaRepository;
        private readonly ProveedorRepository proveedorRepository;
        private readonly UsuarioSesion usuario;

        private readonly Producto? productoEditar;

        // CREAR PRODUCTO
        public ProductoForm(UsuarioSesion usuario)
        {
            InitializeComponent();

            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;

            this.usuario = usuario;

            productoRepository = new ProductoRepository();
            categoriaRepository = new CategoriaRepository();
            proveedorRepository = new ProveedorRepository();

            ConfigurarFormulario();

            CargarCategorias();
            CargarProveedores();

            Text = "Nuevo producto";
        }

        // EDITAR PRODUCTO
        public ProductoForm(
            UsuarioSesion usuario,
            Producto producto
        ) : this(usuario)
        {
            productoEditar = producto;

            Text = "Editar producto";

            CargarDatosProducto();
        }

        private void ConfigurarFormulario()
        {
            txtDescripcion.Multiline = true;

            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Minimum = 0;
            nudPrecio.Maximum = 1000000;

            nudStock.Minimum = 0;
            nudStock.Maximum = 100000;

            dtpFechaCaducidad.Format =
                DateTimePickerFormat.Short;

            chkSinCaducidad.Checked = false;
            dtpFechaCaducidad.Enabled = true;
        }

        private void CargarCategorias()
        {
            try
            {
                var categorias = categoriaRepository.Listar();

                cmbCategoria.DataSource = null;
                cmbCategoria.DataSource = categorias;

                cmbCategoria.DisplayMember = "Nombre";
                cmbCategoria.ValueMember = "IdCategoria";

                cmbCategoria.DropDownStyle =
                    ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudieron cargar las categorías.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarProveedores()
        {
            try
            {
                var proveedores = proveedorRepository.Listar();

                cmbProveedores.DataSource = null;
                cmbProveedores.DataSource = proveedores;

                cmbProveedores.DisplayMember = "Nombre";
                cmbProveedores.ValueMember = "IdProveedor";

                cmbProveedores.DropDownStyle =
                    ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudieron cargar los proveedores.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarDatosProducto()
        {
            if (productoEditar == null)
            {
                return;
            }

            txtNombre.Text =
                productoEditar.Nombre;

            txtDescripcion.Text =
                productoEditar.Descripcion ?? string.Empty;

            cmbCategoria.SelectedValue =
                productoEditar.IdCategoria;

            if (productoEditar.IdProveedor.HasValue)
            {
                cmbProveedores.SelectedValue =
                    productoEditar.IdProveedor.Value;
            }

            nudPrecio.Value =
                productoEditar.Precio;

            nudStock.Value =
                productoEditar.Stock;

            if (productoEditar.FechaCaducidad.HasValue)
            {
                chkSinCaducidad.Checked = false;

                dtpFechaCaducidad.Enabled = true;

                dtpFechaCaducidad.Value =
                    productoEditar.FechaCaducidad.Value;
            }
            else
            {
                chkSinCaducidad.Checked = true;

                dtpFechaCaducidad.Enabled = false;
            }
        }

        private void chkSinCaducidad_CheckedChanged(
            object sender,
            EventArgs e)
        {
            dtpFechaCaducidad.Enabled =
                !chkSinCaducidad.Checked;
        }

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidarFormulario())
            {
                return;
            }

            try
            {
                Producto producto = new Producto
                {
                    IdProducto =
                        productoEditar?.IdProducto ?? 0,

                    IdCategoria =
                        Convert.ToInt32(
                            cmbCategoria.SelectedValue
                        ),

                    IdProveedor =
                        Convert.ToInt32(
                            cmbProveedores.SelectedValue
                        ),

                    Nombre =
                        txtNombre.Text.Trim(),

                    Descripcion =
                        string.IsNullOrWhiteSpace(
                            txtDescripcion.Text
                        )
                            ? null
                            : txtDescripcion.Text.Trim(),

                    Precio =
                        nudPrecio.Value,

                    Stock =
                        Convert.ToInt32(
                            nudStock.Value
                        ),

                    FechaCaducidad =
                        chkSinCaducidad.Checked
                            ? null
                            : dtpFechaCaducidad.Value.Date
                };

                if (productoEditar == null)
                {
                    productoRepository.Crear(
                        producto,
                        usuario.IdUsuario
                    );

                    MessageBox.Show(
                        "Producto creado correctamente.",
                        "Producto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    productoRepository.Actualizar(
                        producto,
                        usuario.IdUsuario
                    );

                    MessageBox.Show(
                        "Producto actualizado correctamente.",
                        "Producto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo guardar el producto.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Ingresa el nombre del producto.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNombre.Focus();

                return false;
            }

            if (cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show(
                    "Selecciona una categoría.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbCategoria.Focus();

                return false;
            }

            if (cmbProveedores.SelectedValue == null)
            {
                MessageBox.Show(
                    "Selecciona un proveedor.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbProveedores.Focus();

                return false;
            }

            if (nudPrecio.Value <= 0)
            {
                MessageBox.Show(
                    "El precio debe ser mayor que cero.",
                    "Precio inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                nudPrecio.Focus();

                return false;
            }

            return true;
        }

        private void btnCancelar_Click(
            object sender,
            EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

    }
}