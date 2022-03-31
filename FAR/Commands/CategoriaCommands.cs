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
                               SET [Nombre] = @Nombre
                                  ,[Descripcion] = @Descripcion
                             WHERE Id_Categoria =" + categoria.Id_Categoria + ";";
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
                         (@Nombre,@Descripcion);";

            using (var connection = new SqlConnection(_GetConnection))
            {
                var affectedRows = connection.Execute(sql, categoria);
            }

            return categoria;
        }

        public Categorias BorrarCategoria(int id)
        {
            Categorias categorias;
            string sql = "Select * from [dbo].[Categorias] where Id_Categoria = " + id + ";";
            using (var connection = new SqlConnection(_GetConnection))
            {
                categorias = connection.Query<Categorias>(sql).FirstOrDefault();
            }
            if (categorias.Id_Categoria == 0)
            {
                this.BorrarCategoria(id);
            }
            else
            {

            }
            return categorias;
        }

    }
}
