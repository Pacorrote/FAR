using Dapper;
using FAR.Models;
using System.Data.SqlClient;

namespace FAR.Commands
{
    public class CarritoCommand : ICarritoCommand
    {
        private readonly string CONNECTIONSTRING;

        public CarritoCommand(string CONNECTIONSTRING)
        {
            this.CONNECTIONSTRING = CONNECTIONSTRING;
        }
        public bool ModifyCarrito(Carrito carrito)
        {
            string sql = @"UPDATE [dbo].[Carrito]
                               SET [Folio] = @Folio
                                  ,[Cancelado] = @Cancelado
                                  ,[Total_venta] = @Total_venta
                         WHERE Id_Carrito = " + carrito.Id_Carrito + ";";
            try
            {
                using (var connection = new SqlConnection(CONNECTIONSTRING))
                {
                    var affectedRows = connection.Execute(sql, carrito);
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

        public Carrito RemoveCarrito(int id)
        {
            Carrito carrito;
            string sql = "Select * from [dbo].[Carrito] where Id_Carrito = " + id + ";";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                carrito = connection.Query<Carrito>(sql).FirstOrDefault();
            }
            sql = "DELETE FROM [dbo].[Carrito] WHERE Id_Carrito = " + id + ";";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                var rowAffected = connection.Execute(sql);
            }
            return carrito;
        }

        public bool SaveCarrito(Carrito newCarrito)
        {
            string sql = @"
                        INSERT INTO [dbo].[Carrito]
                                   ([Folio]
                                   ,[Cancelado]
                                   ,[Total_venta])
                             VALUES
                                   (@Folio
                                   ,@Cancelado
                                   ,@Total_venta)
                        ";
            try
            {
                using (var connection = new SqlConnection(CONNECTIONSTRING))
                {
                    var affectedRows = connection.Execute(sql, newCarrito);
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
