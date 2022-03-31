using System.ComponentModel.DataAnnotations;

namespace FAR.Models
{
    public class UsuarioCarrito
    {
        [Key]
        public int Id_Usuario_Carrito { get; set; }
        public int Id_Carrito { get; set; }
        public int Id_Usuario { get; set; }
    }
}
