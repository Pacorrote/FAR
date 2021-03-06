using System.ComponentModel.DataAnnotations;

namespace FAR.Models
{
    public class Productos
    {
        [Key]
        public int Id_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public float Precio { get; set; }
        public bool Habilitado { get; set; }
        public int Id_Categoria { get; set; }
        public int Id_Usuario { get; set; }
    }
}
