using ModernStore.Models;
using ModernStore.Repositories;

namespace ModernStore.Forms
{
    public partial class ProveedorForm : Form
    {
        private readonly ProveedorRepository proveedorRepository;
        private readonly UsuarioSesion usuario;

        private readonly Proveedor? proveedorEditar;

        // CREAR PROVEEDOR
        public ProveedorForm(UsuarioSesion usuario)
        {
            InitializeComponent();

            this.usuario = usuario;

            proveedorRepository =
                new ProveedorRepository();

            Text = "Nuevo proveedor";
        }

        // EDITAR PROVEEDOR
        public ProveedorForm(
            UsuarioSesion usuario,
            Proveedor proveedor
        ) : this(usuario)
        {
            proveedorEditar = proveedor;

            Text = "Editar proveedor";

            CargarDatosProveedor();
        }

        private void CargarDatosProveedor()
        {
            if (proveedorEditar == null)
            {
                return;
            }

            txtNombre.Text =
                proveedorEditar.Nombre;

            txtTelefono.Text =
                proveedorEditar.Telefono ?? string.Empty;

            txtCorreo.Text =
                proveedorEditar.Correo ?? string.Empty;
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
                Proveedor proveedor = new Proveedor
                {
                    IdProveedor =
                        proveedorEditar?.IdProveedor ?? 0,

                    Nombre =
                        txtNombre.Text.Trim(),

                    Telefono =
                        string.IsNullOrWhiteSpace(
                            txtTelefono.Text
                        )
                            ? null
                            : txtTelefono.Text.Trim(),

                    Correo =
                        string.IsNullOrWhiteSpace(
                            txtCorreo.Text
                        )
                            ? null
                            : txtCorreo.Text.Trim()
                };

                if (proveedorEditar == null)
                {
                    proveedorRepository.Crear(
                        proveedor,
                        usuario.IdUsuario
                    );

                    MessageBox.Show(
                        "Proveedor creado correctamente.",
                        "Proveedores",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    proveedorRepository.Actualizar(
                        proveedor,
                        usuario.IdUsuario
                    );

                    MessageBox.Show(
                        "Proveedor actualizado correctamente.",
                        "Proveedores",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                DialogResult =
                    DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo guardar el proveedor.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(
                txtNombre.Text))
            {
                MessageBox.Show(
                    "Ingresa el nombre del proveedor.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNombre.Focus();

                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtCorreo.Text)
                && !txtCorreo.Text.Contains("@"))
            {
                MessageBox.Show(
                    "Ingresa un correo válido.",
                    "Correo inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtCorreo.Focus();

                return false;
            }

            if (txtTelefono.Text.Trim().Length > 15)
            {
                MessageBox.Show(
                    "El teléfono no puede tener más de 15 caracteres.",
                    "Teléfono inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtTelefono.Focus();

                return false;
            }

            return true;
        }

        private void btnCancelar_Click(
            object sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }
    }
}