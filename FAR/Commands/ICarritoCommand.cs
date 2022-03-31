using FAR.Models;

namespace FAR.Commands
{
    public interface ICarritoCommand
    {
        bool SaveCarrito(Carrito newCarrito);
        bool ModifyCarrito(Carrito carrito);
        Carrito RemoveUsuariosRol(int id);
    }
}
