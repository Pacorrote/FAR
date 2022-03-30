using FAR.DTOs;

namespace FAR.Queries
{
    public interface IUsuariosRolQueries
    {
        UsuariosRolDTO FindByID(uint id);
        List<UsuariosRolDTO> GetAll();
    }
}
