using FAR.Models;

namespace FAR.Commands
{
    public interface IUsuariosRolCommand
    {
        bool SaveUsuariosRol(UsuarioRol newUR);
        bool ModifyUsuariosRol(UsuarioRol usuarioRol);
        UsuarioRol RemoveUsuariosRol(int id);
    }
}
