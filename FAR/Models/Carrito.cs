using System.ComponentModel.DataAnnotations;

namespace FAR.Models
{
    public class Carrito
    {
        [Key]
        public uint Id_Carrito { get; set; }
        public string Folio { get; set; }
        public bool Cancelado { get; set; }
        public float Total_venta { get; set; }
    }
}
