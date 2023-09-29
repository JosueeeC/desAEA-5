using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            dataGrid.ItemsSource = ListarProducto();
        }

        public static string connectionString = "Data Source=LAB1504-22\\SQLEXPRESS;Initial Catalog=Neptuno;User ID=josue;Password=123456";

        private static List<Producto> ListarProducto()
        {
            List<Producto> productos = new List<Producto>();

            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();
                string query = "ListarProductos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verificar si hay filas
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Leer los datos de cada fila
                                productos.Add(new Producto
                                {
                                    idProducto = (int)reader["idproducto"],
                                    nombreProducto = reader["nombreProducto"].ToString(),
                                    idProveedor = (int)reader["IdProducto"],
                                    idCategoria = (int)reader["IdProducto"],
                                    cantidadPorUnidad = reader["idCategoria"].ToString(),
                                    precioUnidad = (decimal)reader["precioUnidad"],
                                    unidadesEnExistencia = (short)reader["unidadesEnExistencia"],
                                    unidadesEnPedido = (short)reader["unidadesEnPedido"],
                                    nivelNuevoPedido = (short)reader["nivelNuevoPedido"],
                                    suspendido = (short)reader["suspendido"],
                                    categoriaProducto = reader["categoriaProducto"].ToString() 
                                });

                            }
                        }
                    }
                }

                // Cerrar la conexión
                connection.Close();


            }
            return productos;

        }

        private void btnAdd(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Show();
        }
    }
}
