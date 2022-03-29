using System.ComponentModel.DataAnnotations;

namespace FAR.Models
{
    public class UsuarioCarrito
    {
        [Key]
        public uint Id_Usuario_Carrito { get; set; }
        public uint Id_Carrito { get; set; }
        public uint Id_Usuario { get; set; }
    }
}
