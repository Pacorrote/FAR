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
            string sql = "Select * from [dbo].[Carrito] where Id_Carrito = "+id+";";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                var carrito = connection.Query<Carrito>(sql).FirstOrDefault();
                return new CarritoDTO
                {
                    Total_venta = carrito.Total_venta,
                    Cancelado = carrito.Cancelado,
                    Folio = carrito.Folio,
                    Id_Carrito = carrito.Id_Carrito,
                };
            }
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
                    list.Add(new CarritoDTO()
                    {
                        Id_Carrito = usuarios[i].Id_Carrito,
                        Cancelado = usuarios[i].Cancelado,
                        Folio = usuarios[i].Folio,
                        Total_venta = usuarios[i].Total_venta,
                    });
                }
            }
            return list;
        }
    }
}
