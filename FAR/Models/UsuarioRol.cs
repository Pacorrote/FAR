using System.ComponentModel.DataAnnotations;

namespace FAR.Models
{
    public class UsuarioRol
    {
        [Key]
        public uint Id_Rol { get; set; }
        public string Tipo_Usuario { get; set; }
    }
}
