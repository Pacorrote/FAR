using System.ComponentModel.DataAnnotations;

namespace FAR.Models
{
    public class ProductosCarrito
    {
        [Key]
        public uint Id_ProductoCarrito { get; set; }
        public float PrecioUnitario { get; set; }
        public uint Cantidad { get; set; }
        public float Total { get; set; }
        public uint Id_Carrito { get; set; }
        public uint Id_Producto { get; set; }

    }
}
