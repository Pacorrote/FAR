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
            throw new NotImplementedException();
        }
        public List<CategoriaDTO> GetAll()
        {
            List<CategoriaDTO> list = new List<CategoriaDTO>();
            string sql = "select * from [dbo].[UsuarioCarrito]";
            using (var connection = new SqlConnection(_GetConnection))
            {
                var categoria = connection.Query<Categorias>(sql).ToList();
                for (int i = 0; i < categoria.Count; i++)
                {
                    list.Add(new CategoriaDTO());
                }
                return list;
            }
        }

    }
}
}
