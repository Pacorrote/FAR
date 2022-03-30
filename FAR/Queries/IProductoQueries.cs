using FAR.DTOs;

namespace FAR.Queries
{
    public interface IProductoQueries
    {
        ProductoDTO FindById(int idProducto);
        public List<ProductoDTO> GetAll()
        {
            return new List<ProductoDTO>();
        }

    }
}
