using FAR.Models;

namespace FAR.Commands
{
    public interface IProductoCarritoCommand
    {
        bool SaveProductoCarrito(ProductosCarrito productosCarrito);
        bool ModifyUsuariosRol(ProductosCarrito productosCarrito);
        ProductosCarrito RemoveUsuariosRol(int id);
    }
}
