using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Producto
    {
        public int idProducto {  get; set; }
        public string nombreProducto { get; set; }
        public int idProveedor { get; set; }
        public int idCategoria { get; set; }
        public string cantidadPorUnidad { get; set; }
        public decimal precioUnidad { get; set; }
        public short unidadesEnExistencia { get; set; }
        public short unidadesEnPedido { get; set; }
        public short nivelNuevoPedido { get; set; }
        public short suspendido { get; set; }
        public string categoriaProducto { get; set; }
    }
}
