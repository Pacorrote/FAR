using FAR.DTOs;

namespace FAR.Queries
{
    public interface ICarritoQueries
    {
        CarritoDTO FindByID(uint id);
        List<CarritoDTO> GetAll();
    }
}
