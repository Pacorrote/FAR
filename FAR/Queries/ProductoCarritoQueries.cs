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
            string sql = "Select * from [dbo].[ProductosCarrito] where Id_ProductoCarrito = " + id + ";";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                var productosCarrito = connection.Query<ProductosCarrito>(sql).FirstOrDefault();
                return new ProductosCarritoDTO
                {
                    Id_ProductoCarrito = productosCarrito.Id_ProductoCarrito,
                    Cantidad = productosCarrito.Cantidad,
                    Id_Carrito = productosCarrito.Id_Carrito,
                    Id_Producto = productosCarrito.Id_Producto,
                    PrecioUnitario = productosCarrito.PrecioUnitario,
                    Total = productosCarrito.Total,
                };
            }
        }

        public List<ProductosCarritoDTO> GetAll()
        {
            List<ProductosCarritoDTO> list = new List<ProductosCarritoDTO>();
            string sql = "Select * from [dbo].[ProductosCarrito]";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                var productosCarrito = connection.Query<ProductosCarrito>(sql).ToList();
                for (int i = 0; i < productosCarrito.Count; i++)
                {
                    list.Add(new ProductosCarritoDTO()
                    {
                        Id_ProductoCarrito = productosCarrito[i].Id_ProductoCarrito,
                        Cantidad = productosCarrito[i].Cantidad,
                        Id_Carrito = productosCarrito[i].Id_Carrito,
                        Id_Producto = productosCarrito[i].Id_Producto,
                        PrecioUnitario = productosCarrito[i].PrecioUnitario,
                        Total = productosCarrito[i].Total,
                    });
                }
            }
            return list;
        }
    }
}
