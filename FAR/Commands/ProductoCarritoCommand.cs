using Dapper;
using FAR.Models;
using System.Data.SqlClient;

namespace FAR.Commands
{
    public class ProductoCarritoCommand : IProductoCarritoCommand
    {
        private readonly string CONNECTIONSTRING;

        public ProductoCarritoCommand(string CONNECTIONSTRING)
        {
            this.CONNECTIONSTRING = CONNECTIONSTRING;
        }
        public bool ModifyUsuariosRol(ProductosCarrito productosCarrito)
        {
            string sql = @"UPDATE [dbo].[ProductosCarrito]
                               SET [Cantidad] = @Cantidad
                                  ,[Total] = @Total
                                  ,[Id_Carrito] = @Id_Carrito
                                  ,[Id_Producto] = @Id_Producto
                         WHERE Id_ProductoCarrito = " + productosCarrito.Id_ProductoCarrito + "; GO";
            try
            {
                using (var connection = new SqlConnection(CONNECTIONSTRING))
                {
                    var affectedRows = connection.Execute(sql, productosCarrito);
                    if (affectedRows > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public ProductosCarrito RemoveUsuariosRol(uint id)
        {
            ProductosCarrito productosCarrito;
            string sql = "Select * from [dbo].[ProductosCarrito] where Id_ProductoCarrito = " + id + ";";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                productosCarrito = connection.Query<ProductosCarrito>(sql).FirstOrDefault();
            }
            sql = "DELETE FROM [dbo].[ProductosCarrito] WHERE Id_Usuario = " + id + ";";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                var rowAffected = connection.Execute(sql);
            }
            return productosCarrito;
        }

        public bool SaveProductoCarrito(ProductosCarrito productosCarrito)
        {
            string sql = @"
                        INSERT INTO [dbo].[ProductosCarrito]
                                   ([Cantidad]
                                   ,[Total]
                                   ,[Id_Carrito]
                                   ,[Id_Producto])
                             VALUES
                                   (@Cantidad
                                   ,@Total
                                   ,@Id_Carrito
                                   ,@Id_Producto)
                        GO
                        ";
            try
            {
                using (var connection = new SqlConnection(CONNECTIONSTRING))
                {
                    var affectedRows = connection.Execute(sql, productosCarrito);
                    if (affectedRows > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
