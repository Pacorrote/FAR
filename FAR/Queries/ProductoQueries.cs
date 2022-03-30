using Dapper;
using FAR.DTOs;
using FAR.Models;
using System.Data.SqlClient;

namespace FAR.Queries
{
    internal class ProductoQueries : IProductoQueries
    {
        private readonly string _GetConnection;

        public ProductoQueries(string getConnection)
        {
            _GetConnection = getConnection;
        }
        public ProductoDTO FindById(int idProducto)
        {
            throw new NotImplementedException();
        }
        public List<ProductoDTO> GetAll()
        {
            List<ProductoDTO> list = new List<ProductoDTO>();
            string sql = "select * from [dbo].[Productos]";
            using (var connection = new SqlConnection(_GetConnection))
            {
                var producto = connection.Query<Productos>(sql).ToList();
                for (int i = 0; i < producto.Count; i++)
                {
                    list.Add(new ProductoDTO());
                }
                return list;
            }
        }

    }
}
