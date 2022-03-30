using Dapper;
using FAR.Models;
using System.Data.SqlClient;

namespace FAR.Commands
{
    public class ProductoCommands : IProductoCommands
    {
        private readonly string _GetConnection;
        public ProductoCommands(string GetConnection) 
        {
            this._GetConnection=GetConnection;
        }

        public Productos AgregarProducto(Productos producto)
        {
            string sqlAProducto = @"INSERT INTO [dbo].[Productos](Nombre,Descripcion,Stock,Precio,Habilitado,Id_Categoria) VALUES
                         (@Nombre,@Descripcion,@Stock,@Precio,@Habilitado,@Id_Categoria); GO";

                using (var connection = new SqlConnection(_GetConnection))
                {
                    var affectedRows = connection.Execute(sqlAProducto, producto);
                }

            return producto;

        }

        public bool ActualizarProducto(Productos producto)
        {
            var sqlUProducto = @"
                        UPDATE [dbo].[Productos]
                               SET [Id_Producto] = @Id_Producto
                                  ,[Nombre] = @Nombre
                                  ,[Descripcion] = @Descripcion
                                  ,[Stock] = @Stock
                                  ,[Precio] = @Precio
                                  ,[Habilitado] = @Habilitado
                                  ,[Id_Categoria] = @Id_Categoria
                             WHERE Id_Producto =" + producto.Id_Producto + "; GO";
            try
            {
                using (var connection = new SqlConnection(_GetConnection))
                {
                    var affectedRows = connection.Execute(sqlUProducto, producto);
                    if (affectedRows > 0) 
                    {
                        return true;
                    }
                    return false;

                }
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public Productos BorrarProducto(uint id)
        {
            Productos producto;
            string sqlBProducto = "SELECT * FROM [dbo].[Productos] WHERE Id_Producto =" + id + ";";
            using (var connection = new SqlConnection(_GetConnection))  
            {
                producto = connection.Query<Productos>(sqlBProducto).FirstOrDefault();
 
            }

           string sql = "UPDATE Productos SET  Habilitado = " + 0 + " WHERE Id_Producto=" + id + ";";

           using (var connection = new SqlConnection(_GetConnection))
           {
                    var rowAffected = connection.Execute(sqlBProducto);
           }
           return producto;            
        }

        public bool GuardarProducto(Productos producto)
        {
            string sqlGProducto = @"INSERT INTO [dbo].[Productos](Nombre,Descripcion,Stock,Precio,Habilitado,Id_Categoria,) VALUES
                         (@Nombre,@Descripcion,@Stock,@Precio,@Habilitado,@Id_Categoria); GO";
            try
            {
                using (var connection = new SqlConnection(_GetConnection))
                {
                    var affectedRows = connection.Execute(sqlGProducto, producto);
                    if (affectedRows > 0)
                    {
                        return true;
                    }
                    return false;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
