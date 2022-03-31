using FAR.DTOs;

namespace FAR.Queries
{
    public interface ICarritoQueries
    {
        CarritoDTO FindByID(int id);
        List<CarritoDTO> GetAll();
    }
}
