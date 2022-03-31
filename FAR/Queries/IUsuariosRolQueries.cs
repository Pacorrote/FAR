using FAR.DTOs;

namespace FAR.Queries
{
    public interface IUsuariosRolQueries
    {
        UsuariosRolDTO FindByID(int id);
        List<UsuariosRolDTO> GetAll();
    }
}
