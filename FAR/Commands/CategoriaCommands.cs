using Dapper;
using FAR.Models;
using System.Data.SqlClient;

namespace FAR.Commands
{
    public class CategoriaCommands : ICategoriaCommands
    {
        private readonly string _GetConnection;
        public CategoriaCommands(string GetConnection)
        {
            this._GetConnection = GetConnection;
        }
        public bool ActualizarCategoria(Categorias categoria)
        {
            var sql = @"
                        UPDATE [dbo].[Categorias]
                               SET [Id_Categoria] = @Id_Categoria
                                  ,[Nombre] = @Nombre
                                  ,[Descripcion] = @Descripcion
                             WHERE Id_Categoria =" + categoria.Id_Categoria + "; GO";
            try
            {
                using (var connection = new SqlConnection(_GetConnection))
                {
                    var affectedRows = connection.Execute(sql, categoria);
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

        public Categorias AgregarCategoria(Categorias categoria)
        {
            string sql = @"INSERT INTO [dbo].[Categorias](Nombre,Descripcion) VALUES
                         (@Nombre,@Descripcion); GO";

            using (var connection = new SqlConnection(_GetConnection))
            {
                var affectedRows = connection.Execute(sql, categoria);
            }

            return categoria;
        }

        public Categorias BorrarCategoria(uint id)
        {
            Categorias categoria;
            string sqlD = "SELECT * FROM [dbo].[Categorias] WHERE Id_Categoria =" + id + ";";
            using (var connection = new SqlConnection(_GetConnection))
            {
                categoria = connection.Query<Categorias>(sqlD).FirstOrDefault();

            }

            string sql = "DELETE FROM Categorias WHERE Id_Categoria = " + id + ";";

            using (var connection = new SqlConnection(_GetConnection))
            {
                var rowAffected = connection.Execute(sql);
            }
            return categoria;
        }

    }
}
