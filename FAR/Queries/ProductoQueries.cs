using Dapper;
using FAR.DTOs;
using FAR.Models;
using Microsoft.AspNetCore.Mvc;
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
                    Nombre = productos.Nombre,
                    Descripcion = productos.Descripcion,
                    Stock = productos.Stock,
                    Precio = productos.Precio,
                    Habilitado = productos.Habilitado,
                    Id_Categoria = productos.Id_Categoria,
                    Id_Usuario = productos.Id_Usuario,
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
                        Nombre = producto[i].Nombre,
                        Descripcion = producto[i].Descripcion,
                        Stock = producto[i].Stock,
                        Precio = producto[i].Precio,
                        Habilitado = producto[i].Habilitado,
                        Id_Categoria = producto[i].Id_Categoria,
                        Id_Usuario = producto[i].Id_Usuario,
                    });
                }
                return list;
            }
        }

        public int Productos()
        {
            string sql = "SELECT COUNT(Id_Producto) AS PRODUCTOS FROM Productos;";
            using (var connection = new SqlConnection(_GetConnection))
            {
                var productos = connection.Query<int>(sql).FirstOrDefault();
                return productos;
            }
        }
    }
}
