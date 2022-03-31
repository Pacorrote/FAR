using System.ComponentModel.DataAnnotations;

namespace FAR.Models
{
    public class Productos
    {
        [Key]
        public uint Id_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public uint Stock { get; set; }
        public float Precio { get; set; }
        public bool Habilitado { get; set; }
        public uint Id_Categoria { get; set; }
        public uint Id_Usuario { get; set; }
    }
}
