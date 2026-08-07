using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;
using ModernStore.Repositories;
using ModernStore.Utils;

namespace ModernStore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            TestConnection();

            var repository = new ProductoRepository();

            List<Producto> productos = repository.Listar();

            MessageBox.Show($"Se encontraron {productos.Count} productos en la base de datos.");
        }

        private void TestConnection()
        {
            try
            {
                using SqlConnection connection = Database.GetConnection();
                
                connection.Open();

                MessageBox.Show("Conexion establecida correctamente.");
            }
            catch (Exception ex)  
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
