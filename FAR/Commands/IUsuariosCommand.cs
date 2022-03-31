using FAR.Models;

namespace FAR.Commands
{
    public interface IUsuariosCommand
    {
        bool SaveProductoCarrito(Usuarios newUsuario);
        bool ModifyUsuariosRol(Usuarios usuario);
        Usuarios RemoveUsuariosRol(int id);
    }
}
