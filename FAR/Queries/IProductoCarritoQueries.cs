using FAR.DTOs;

namespace FAR.Queries
{
    public interface IProductoCarritoQueries
    {
        ProductosCarritoDTO FindByID(uint id);
        List<ProductosCarritoDTO> GetAll();
    }
}
