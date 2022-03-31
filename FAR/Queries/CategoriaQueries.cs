using Dapper;
using FAR.DTOs;
using FAR.Models;
using System.Data.SqlClient;

namespace FAR.Queries
{
    public class CategoriasQueries:ICategoriaQueries
    {
        private readonly string _GetConnection;

        public CategoriasQueries(string getConnection)
        {
            _GetConnection = getConnection;
        }
        public CategoriaDTO FindById(int idCategoria)
        {
            string sql = "Select * from [dbo].[Categorias] where Id_Categoria = " + idCategoria + ";";
            using (var connection = new SqlConnection(_GetConnection))
            {
                var categoria = connection.Query<Categorias>(sql).FirstOrDefault();
                return new CategoriaDTO
                {
                    Id_Categoria = categoria.Id_Categoria,
                    Nombre = categoria.Nombre,
                    Descripcion = categoria.Descripcion,
                };
            }
        }
        public List<CategoriaDTO> GetAll()
        {
            List<CategoriaDTO> list = new List<CategoriaDTO>();
            string sql = "select * from [dbo].[Categorias]";
            using (var connection = new SqlConnection(_GetConnection))
            {
                var categoria = connection.Query<Categorias>(sql).ToList();
                for (int i = 0; i < categoria.Count; i++)
                {
                    list.Add(new CategoriaDTO()
                    {
                        Id_Categoria = categoria[i].Id_Categoria,
                        Nombre = categoria[i].Nombre,
                        Descripcion = categoria[i].Descripcion,
                    });
                }
                return list;
            }
        }

    }
}

