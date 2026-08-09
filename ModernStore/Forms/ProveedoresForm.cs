using ModernStore.Models;
using ModernStore.Repositories;

namespace ModernStore.Forms
{
    public partial class ProveedoresForm : Form
    {
        private readonly ProveedorRepository proveedorRepository;
        private readonly UsuarioSesion usuario;

        private List<Proveedor> proveedores = new();

        public ProveedoresForm(UsuarioSesion usuario)
        {
            InitializeComponent();

            this.usuario = usuario;

            proveedorRepository =
                new ProveedorRepository();

            CargarProveedores();
        }

        private void CargarProveedores()
        {
            try
            {
                proveedores =
                    proveedorRepository.Listar();

                dgvProveedores.DataSource = null;
                dgvProveedores.DataSource = proveedores;
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

        private void txtBuscar_TextChanged(
            object sender,
            EventArgs e)
        {
            string texto =
                txtBuscar.Text.Trim().ToLower();

            var filtrados = proveedores
                .Where(p =>
                    p.Nombre
                        .ToLower()
                        .Contains(texto)
                    ||
                    (p.Telefono ?? string.Empty)
                        .ToLower()
                        .Contains(texto)
                    ||
                    (p.Correo ?? string.Empty)
                        .ToLower()
                        .Contains(texto)
                )
                .ToList();

            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = filtrados;
        }

        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            using ProveedorForm proveedorForm =
                new ProveedorForm(usuario);

            if (proveedorForm.ShowDialog()
                == DialogResult.OK)
            {
                CargarProveedores();
            }
        }

        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecciona un proveedor para editar.",
                    "Proveedores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            Proveedor proveedor =
                (Proveedor)dgvProveedores
                    .CurrentRow
                    .DataBoundItem;

            using ProveedorForm proveedorForm =
                new ProveedorForm(
                    usuario,
                    proveedor
                );

            if (proveedorForm.ShowDialog()
                == DialogResult.OK)
            {
                CargarProveedores();
            }
        }

        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecciona un proveedor para eliminar.",
                    "Proveedores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            Proveedor proveedor =
                (Proveedor)dgvProveedores
                    .CurrentRow
                    .DataBoundItem;

            DialogResult confirmacion =
                MessageBox.Show(
                    $"¿Estás seguro de eliminar al proveedor '{proveedor.Nombre}'?",
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
                proveedorRepository.Eliminar(
                    proveedor.IdProveedor,
                    usuario.IdUsuario
                );

                MessageBox.Show(
                    "Proveedor eliminado correctamente.",
                    "Proveedores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarProveedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo eliminar el proveedor.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}