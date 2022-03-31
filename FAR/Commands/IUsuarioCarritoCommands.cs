using FAR.Models;

namespace FAR.Commands
{
    public interface IUsuarioCarritoCommands
    {
        bool ActualizarUsuarioCarrito(UsuarioCarrito usuarioCarrito);
        UsuarioCarrito AgregarUsuarioCarrito(UsuarioCarrito usuarioCarrito);
        UsuarioCarrito BorrarUsuarioCarrito(int id);
        bool GuardarUsuarioCarrito(UsuarioCarrito usuario);
    }
}
