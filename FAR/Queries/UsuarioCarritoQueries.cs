using Dapper;
using FAR.DTOs;
using FAR.Models;
using System.Data.SqlClient;

namespace FAR.Queries
{
    public class UsuarioCarritoQueries : IUsuarioCarritoQueries
    {
        private readonly string _GetConnection;

        public UsuarioCarritoQueries(string getConnection)
        {
            _GetConnection = getConnection;
        }

        public UsuarioCarritoDTO FindById(int idUsuarioCarrito)
        {
            throw new NotImplementedException();
        }
        public List<UsuarioCarritoDTO> GetAll() 
        {
            List<UsuarioCarritoDTO> list = new List<UsuarioCarritoDTO>();
            string sql = "select * from [dbo].[UsuarioCarrito]";
            using (var connection = new SqlConnection(_GetConnection))
            {
                var usuarioCarrito = connection.Query<Usuarios>(sql).ToList();
                for (int i = 0; i < usuarioCarrito.Count; i++) 
                {
                    list.Add(new UsuarioCarritoDTO());
                }
                return list;
            }
        }

    }
}
