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

        public CarritoDTO FindByID(int id)
        {
            string sql = "Select * from [dbo].[Carrito] where Id_Carrito = "+id+";";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                var carrito = connection.Query<Carrito>(sql).FirstOrDefault();
                return new CarritoDTO
                {
                    Id_Carrito = carrito.Id_Carrito,
                    Folio = carrito.Folio,
                    Cancelado = carrito.Cancelado,
                    Total_venta = carrito.Total_venta,
                };
            }
        }

        public List<CarritoDTO> GetAll()
        {
            List<CarritoDTO> list = new List<CarritoDTO>();
            string sql = "Select * from [dbo].[Carrito]";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                var carrito = connection.Query<Carrito>(sql).ToList();
                for (int i = 0; i < carrito.Count; i++)
                {
                    list.Add(new CarritoDTO()
                    {
                        Id_Carrito = carrito[i].Id_Carrito,
                        Folio = carrito[i].Folio,
                        Cancelado = carrito[i].Cancelado,
                        Total_venta = carrito[i].Total_venta,
                    });
                }
            }
            return list;
        }
    }
}
