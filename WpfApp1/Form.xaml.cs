using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para Form.xaml
    /// </summary>
    public partial class Form : Window
    {
        public Form()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         

                Producto producto = new Producto();
                producto.idProducto = int.Parse(txtIdProducto.Text);
                producto.nombreProducto = txtIdProducto.Text;
                producto.idProveedor = int.Parse(txtIdProveedor.Text);
                producto.idCategoria = int.Parse(txtIdCategoria.Text);
                producto.categoriaProducto = txtCategoriaProducto.Text;
                producto.precioUnidad = decimal.Parse(txtPrecioUnidad.Text);
                producto.unidadesEnExistencia = short.Parse(txtUnidadesEnExistencia.Text);
                producto.unidadesEnPedido = short.Parse(txtUnidadesEnPedido.Text);
                producto.nivelNuevoPedido = short.Parse(txtNivelNuevoPedido.Text);
                producto.suspendido = short.Parse(txtSuspendido.Text);
                producto.categoriaProducto = txtCategoriaProducto.Text;

            InsertProduct(producto);

            }


        private void InsertProduct(Producto request)
        {

            try
            {

                string connectionString = "Data Source=LAB1504-22\\SQLEXPRESS;Initial Catalog=Neptuno;User ID=josue;Password=123456";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("InsertProductos", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@idProducto", request.idProducto);
                    cmd.Parameters.AddWithValue("@nombreProducto", request.nombreProducto);
                    cmd.Parameters.AddWithValue("@idProveedor", request.idProveedor);
                    cmd.Parameters.AddWithValue("@idCategoria", request.idCategoria);
                    cmd.Parameters.AddWithValue("@cantidadPorUnidad", request.cantidadPorUnidad);
                    cmd.Parameters.AddWithValue("@precioUnidad", request.precioUnidad);
                    cmd.Parameters.AddWithValue("@unidadesEnExistencia",request.unidadesEnExistencia);
                    cmd.Parameters.AddWithValue("@unidadesEnPedido", request.unidadesEnPedido);
                    cmd.Parameters.AddWithValue("@nivelNuevoPedido", request.nivelNuevoPedido);
                    cmd.Parameters.AddWithValue("@suspendido", request.suspendido);
                    cmd.Parameters.AddWithValue("@categoriaProducto", request.categoriaProducto);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Categoría ingresada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar la categoría: " + ex.Message);
            }

        }
    }
}
