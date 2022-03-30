namespace FAR.DTOs
{
    public class UsuariosDTO
    {
        public uint Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Calle { get; set; }
        public uint Id_Localidad { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Contrasena { get; set; }
        public string Username { get; set; }
        public uint Id_Rol { get; set; }
    }
}
