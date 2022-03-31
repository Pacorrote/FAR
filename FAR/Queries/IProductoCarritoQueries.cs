using FAR.DTOs;

namespace FAR.Queries
{
    public interface IProductoCarritoQueries
    {
        ProductosCarritoDTO FindByID(int id);
        List<ProductosCarritoDTO> GetAll();
    }
}
