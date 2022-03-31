using FAR.Models;

namespace FAR.Commands
{
    public interface IUsuariosCommand
    {
        bool SaveUsuario(Usuarios newUsuario);
        bool ModifyUsuarios(Usuarios usuario);
        Usuarios RemoveUsuarios(int id);
    }
}
