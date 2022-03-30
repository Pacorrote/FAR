using FAR.Models;

namespace FAR.Commands
{
    public interface IUsuarioCarritoCommands
    {
        bool ActualizarUsuarioCarrito(UsuarioCarrito usuarioCarrito);
        UsuarioCarrito AgregarUsuarioCarrito(UsuarioCarrito usuarioCarrito);
        UsuarioCarrito BorrarUsuarioCarrito(uint id);
        bool GuardarUsuarioCarrito(UsuarioCarrito usuario);
    }
}
