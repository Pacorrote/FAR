using Dapper;
using FAR.Models;
using System.Data.SqlClient;

namespace FAR.Commands
{
    public class UsuarioCarritoCommands : IUsuarioCarritoCommands
    {
        private readonly string _GetConnection;
        public UsuarioCarritoCommands(string GetConnection)
        {
            this._GetConnection = GetConnection;
        }


        public UsuarioCarrito AgregarUsuarioCarrito(UsuarioCarrito usuarioCarrito)
        {
            string sql = @"INSERT INTO [dbo].[UsuarioCarrito](Id_Carrito,Id_Usuario) VALUES
                         (@Id_Carrito,@Id_Usuario); GO";

            using (var connection = new SqlConnection(_GetConnection))
            {
                var affectedRows = connection.Execute(sql, usuarioCarrito);
            }

            return usuarioCarrito;
        }

        public bool ActualizarUsuarioCarrito(UsuarioCarrito usuarioCarrito)
        {
            var sql = @"
                        UPDATE [dbo].[UsuarioCarrito]
                               SET [Id_Usuario_Carrito] = @Id_Usuario_Carrito
                                  ,[Id_Carrito] = @Id_Carrito
                                  ,[Id_Usuario] = @Id_Usuario
                             WHERE Id_Usuario_Carrito =" + usuarioCarrito.Id_Usuario_Carrito + "; GO";
            try
            {
                using (var connection = new SqlConnection(_GetConnection))
                {
                    var affectedRows = connection.Execute(sql, usuarioCarrito);
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

        

        public bool GuardarUsuarioCarrito(UsuarioCarrito usuarioCarrito)
        {
            string sql = @"INSERT INTO [dbo].[UsuarioCarrito](Id_Carrito,Id_Usuario) VALUES
                         (@Id_Carrito,@Id_Usuario); GO";
            try
            {
                using (var connection = new SqlConnection(_GetConnection))
                {
                    var affectedRows = connection.Execute(sql, usuarioCarrito);
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

        public UsuarioCarrito BorrarUsuarioCarrito(uint id)
        {
            UsuarioCarrito usuarioCarrito;
            string sql = "SELECT * FROM [dbo].[UsuarioCarrito] WHERE Id_Usuario_Carrito =" + id + ";";
            using (var connection = new SqlConnection(_GetConnection))
            {
                usuarioCarrito = connection.Query<UsuarioCarrito>(sql).FirstOrDefault();

            }

           
            return usuarioCarrito;
        }
    }
}
