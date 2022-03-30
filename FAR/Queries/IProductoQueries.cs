using FAR.DTOs;

namespace FAR.Queries
{
    public interface IProductoQueries
    {
        ProductoDTO FindById(int idProducto);
        List<ProductoDTO> GetAll();

        uint Productos();

    }
}
