using FAR.Models;

namespace FAR.Commands
{
    public interface IProductoCommands
    {
        bool ActualizarProducto(Productos producto);
        Productos AgregarProducto(Productos producto);
        Productos BorrarProducto(uint id);
        bool GuardarProducto(Productos producto);
    }
}
