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
            string sql = "Select * from [dbo].[Productos] where Id_Producto = " + idProducto + ";";
            using (var connection = new SqlConnection(_GetConnection))
            {
                var productos = connection.Query<Productos>(sql).FirstOrDefault();
                return new ProductoDTO
                {
                    Id_Producto = productos.Id_Producto,
                    Descripcion = productos.Descripcion,
                    Habilitado = productos.Habilitado,
                    Id_Categoria = productos.Id_Categoria,
                    Nombre = productos.Nombre,
                    Precio = productos.Precio,
                    Stock = productos.Stock,
                };
            }
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
                    list.Add(new ProductoDTO()
                    {
                        Id_Producto = producto[i].Id_Producto,
                        Descripcion = producto[i].Descripcion,
                        Habilitado = producto[i].Habilitado,
                        Id_Categoria = producto[i].Id_Categoria,
                        Nombre = producto[i].Nombre,
                        Precio = producto[i].Precio,
                        Stock = producto[i].Stock,
                    });
                }
                return list;
            }
        }

    }
}
