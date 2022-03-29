using System.ComponentModel.DataAnnotations;

namespace FAR.Models
{
    public class ProductosCarrito
    {
        [Key]
        public uint Id_ProductosCarrito { get; set; }
        public double PrecioUnitario { get; set; }
        public uint Cantidad { get; set; }
        public double Total { get; set; }
        public uint Id_Carrito { get; set; }
        public uint Id_Producto { get; set; }

    }
}
