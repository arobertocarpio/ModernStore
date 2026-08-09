using ModernStore.Models;
using ModernStore.Repositories;

namespace ModernStore.Forms
{
    public partial class ClienteForm : Form
    {
        private readonly ClienteRepository clienteRepository;
        private readonly UsuarioSesion usuario;

        private readonly Cliente? clienteEditar;

        // CREAR
        public ClienteForm(UsuarioSesion usuario)
        {
            InitializeComponent();

            this.usuario = usuario;

            clienteRepository =
                new ClienteRepository();

            Text = "Nuevo cliente";
        }

        // EDITAR
        public ClienteForm(
            UsuarioSesion usuario,
            Cliente cliente
        ) : this(usuario)
        {
            clienteEditar = cliente;

            Text = "Editar cliente";

            CargarDatosCliente();
        }

        private void CargarDatosCliente()
        {
            if (clienteEditar == null)
            {
                return;
            }

            txtNombre.Text =
                clienteEditar.Nombre;

            txtApellidoPaterno.Text =
                clienteEditar.ApellidoPaterno;

            txtApellidoMaterno.Text =
                clienteEditar.ApellidoMaterno
                ?? string.Empty;

            txtTelefono.Text =
                clienteEditar.Telefono
                ?? string.Empty;
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
                Cliente cliente = new Cliente
                {
                    IdCliente =
                        clienteEditar?.IdCliente ?? 0,

                    Nombre =
                        txtNombre.Text.Trim(),

                    ApellidoPaterno =
                        txtApellidoPaterno.Text.Trim(),

                    ApellidoMaterno =
                        string.IsNullOrWhiteSpace(
                            txtApellidoMaterno.Text
                        )
                            ? null
                            : txtApellidoMaterno.Text.Trim(),

                    Telefono =
                        string.IsNullOrWhiteSpace(
                            txtTelefono.Text
                        )
                            ? null
                            : txtTelefono.Text.Trim()
                };

                if (clienteEditar == null)
                {
                    clienteRepository.Crear(
                        cliente,
                        usuario.IdUsuario
                    );

                    MessageBox.Show(
                        "Cliente creado correctamente.",
                        "Clientes",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    clienteRepository.Actualizar(
                        cliente,
                        usuario.IdUsuario
                    );

                    MessageBox.Show(
                        "Cliente actualizado correctamente.",
                        "Clientes",
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
                    $"No se pudo guardar el cliente.\n\n{ex.Message}",
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
                    "Ingresa el nombre del cliente.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNombre.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(
                txtApellidoPaterno.Text))
            {
                MessageBox.Show(
                    "Ingresa el apellido paterno.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtApellidoPaterno.Focus();

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