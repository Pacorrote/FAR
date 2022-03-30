using FAR.DTOs;

namespace FAR.Queries
{
    public interface IUsuariosQueries
    {
        UsuariosDTO FindByID(uint id);
        List<UsuariosDTO> GetAll();
    }
}
