using FAR.DTOs;

namespace FAR.Queries
{
    public interface IUsuariosQueries
    {
        UsuariosDTO FindByID(int id);
        List<UsuariosDTO> GetAll();
        UsuariosDTO Login(string Email, string Contrasena);
    }
}
