using ModernStore.Models;
using ModernStore.Repositories;

namespace ModernStore.Forms
{
    public partial class ClientesForm : Form
    {
        private readonly ClienteRepository clienteRepository;
        private readonly UsuarioSesion usuario;

        private List<Cliente> clientes = new();

        public ClientesForm(UsuarioSesion usuario)
        {
            InitializeComponent();

            this.usuario = usuario;

            clienteRepository =
                new ClienteRepository();

            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                clientes =
                    clienteRepository.Listar();

                dgvClientes.DataSource = null;
                dgvClientes.DataSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudieron cargar los clientes.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void txtBuscar_TextChanged(
            object sender,
            EventArgs e)
        {
            string texto =
                txtBuscar.Text.Trim().ToLower();

            var filtrados = clientes
                .Where(c =>
                    c.NombreCompleto
                        .ToLower()
                        .Contains(texto)
                    ||
                    (c.Telefono ?? string.Empty)
                        .ToLower()
                        .Contains(texto)
                )
                .ToList();

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = filtrados;
        }

        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            using ClienteForm clienteForm =
                new ClienteForm(usuario);

            if (clienteForm.ShowDialog()
                == DialogResult.OK)
            {
                CargarClientes();
            }
        }

        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecciona un cliente para editar.",
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            Cliente cliente =
                (Cliente)dgvClientes
                    .CurrentRow
                    .DataBoundItem;

            using ClienteForm clienteForm =
                new ClienteForm(
                    usuario,
                    cliente
                );

            if (clienteForm.ShowDialog()
                == DialogResult.OK)
            {
                CargarClientes();
            }
        }

        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecciona un cliente para eliminar.",
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            Cliente cliente =
                (Cliente)dgvClientes
                    .CurrentRow
                    .DataBoundItem;

            // Protección básica para Público General.
            if (cliente.NombreCompleto
                .Equals(
                    "Público General",
                    StringComparison.OrdinalIgnoreCase
                ))
            {
                MessageBox.Show(
                    "El cliente Público General no puede eliminarse.",
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult confirmacion =
                MessageBox.Show(
                    $"¿Estás seguro de eliminar al cliente '{cliente.NombreCompleto}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            try
            {
                clienteRepository.Eliminar(
                    cliente.IdCliente,
                    usuario.IdUsuario
                );

                MessageBox.Show(
                    "Cliente eliminado correctamente.",
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo eliminar el cliente.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}