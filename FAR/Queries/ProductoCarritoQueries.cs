using Dapper;
using FAR.DTOs;
using FAR.Models;
using System.Data.SqlClient;

namespace FAR.Queries
{
    public class ProductoCarritoQueries : IProductoCarritoQueries
    {
        private readonly string CONNECTIONSTRING;

        public ProductoCarritoQueries(string CONNECTIONSTRING)
        {
            this.CONNECTIONSTRING = CONNECTIONSTRING;
        }

        public ProductosCarritoDTO FindByID(uint id)
        {
            throw new NotImplementedException();
        }

        public List<ProductosCarritoDTO> GetAll()
        {
            List<ProductosCarritoDTO> list = new List<ProductosCarritoDTO>();
            string sql = "Select * from [dbo].[ProductosCarrito]";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                var usuarios = connection.Query<ProductosCarrito>(sql).ToList();
                for (int i = 0; i < usuarios.Count; i++)
                {
                    list.Add(new ProductosCarritoDTO());
                }
            }
            return list;
        }
    }
}
