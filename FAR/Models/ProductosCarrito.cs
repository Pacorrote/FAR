using System.ComponentModel.DataAnnotations;

namespace FAR.Models
{
    public class ProductosCarrito
    {
        [Key]
        public int Id_ProductoCarrito { get; set; }
        public float PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public float Total { get; set; }
        public int Id_Carrito { get; set; }
        public int Id_Producto { get; set; }

    }
}
