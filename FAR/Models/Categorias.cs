using System.ComponentModel.DataAnnotations;

namespace FAR.Models
{
    public class Categorias
    {
        [Key]
        public uint Id_Categoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
