using Dapper;
using FAR.DTOs;
using FAR.Models;
using System.Data.SqlClient;

namespace FAR.Queries
{
    public class CategoriasQueries
    {
        private readonly string _GetConnection;

        public CategoriasQueries(string getConnection)
        {
            _GetConnection = getConnection;
        }

        public CategoriaDTO FindById(int categoria)
        {
            string sql = "Select * from [dbo].[Categoria] where Id_Categoria = " + categoria + ";";
            using (var connection = new SqlConnection(_GetConnection))
            {
                var categoriaR = connection.Query<Categorias>(sql).FirstOrDefault();
                return new CategoriaDTO
                {
                    Id_Categoria = categoriaR.Id_Categoria,
                    Descripcion = categoriaR.Descripcion,
                    Nombre = categoriaR.Nombre,
                };
            }
        }
        public List<CategoriaDTO> GetAll()
        {
            List<CategoriaDTO> list = new List<CategoriaDTO>();
            string sql = "select * from [dbo].[Categoria]";
            using (var connection = new SqlConnection(_GetConnection))
            {
                var categoria = connection.Query<Categorias>(sql).ToList();
                for (int i = 0; i < categoria.Count; i++)
                {
                    list.Add(new CategoriaDTO()
                    {
                        Id_Categoria = categoria[i].Id_Categoria,
                        Descripcion = categoria[i].Descripcion,
                        Nombre = categoria[i].Nombre,
                    });
                }
                return list;
            }
        }

    }
}

