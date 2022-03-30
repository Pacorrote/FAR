using Dapper;
using FAR.DTOs;
using FAR.Models;
using System.Data.SqlClient;

namespace FAR.Queries
{
    public class CarritoQueries : ICarritoQueries
    {
        private readonly string CONNECTIONSTRING;

        public CarritoQueries(string CONNECTIONSTRING)
        {
            this.CONNECTIONSTRING = CONNECTIONSTRING;
        }

        public CarritoDTO FindByID(uint id)
        {
            throw new NotImplementedException();
        }

        public List<CarritoDTO> GetAll()
        {
            List<CarritoDTO> list = new List<CarritoDTO>();
            string sql = "Select * from [dbo].[Carrito]";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                var usuarios = connection.Query<Carrito>(sql).ToList();
                for (int i = 0; i < usuarios.Count; i++)
                {
                    list.Add(new CarritoDTO());
                }
            }
            return list;
        }
    }
}
