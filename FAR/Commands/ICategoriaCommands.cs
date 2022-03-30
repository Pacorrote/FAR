using FAR.Models;

namespace FAR.Commands
{
    public interface ICategoriaCommands
    {
        bool ActualizarCategoria(Categorias categoria);
        Categorias AgregarCategoria(Categorias categoria);
        Categorias BorrarCategoria(uint id);
    }
}
