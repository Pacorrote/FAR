using FAR.DTOs;

namespace FAR.Queries
{
    public interface IUsuarioCarritoQueries
    {
        UsuarioCarritoDTO FindById(int idUsuarioCarrito);
        public List<UsuarioCarritoDTO> GetAll()
        {
            return new List<UsuarioCarritoDTO>();
        }
    }
}
