namespace FAR.DTOs
{
    public class UsuariosDTO
    {
        public int Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Calle { get; set; }
        public int Id_Localidad { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Contrasena { get; set; }
        public string Username { get; set; }
        public int Id_Rol { get; set; }
    }
}
