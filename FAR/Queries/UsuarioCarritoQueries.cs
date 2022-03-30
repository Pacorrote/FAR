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
            string sql = "Select * from [dbo].[UsuarioCarrito] where Id_Usuario_Carrito = " + idUsuarioCarrito + ";";
            using (var connection = new SqlConnection(_GetConnection))
            {
                var usuarioCarrito = connection.Query<UsuarioCarrito>(sql).FirstOrDefault();
                return new UsuarioCarritoDTO
                {
                    Id_Carrito = usuarioCarrito.Id_Carrito,
                    Id_Usuario = usuarioCarrito.Id_Usuario,
                    Id_Usuario_Carrito = usuarioCarrito.Id_Usuario_Carrito
                };
            }
        }
        public List<UsuarioCarritoDTO> GetAll()
        {
            List<UsuarioCarritoDTO> list = new List<UsuarioCarritoDTO>();
            string sql = "select * from [dbo].[UsuarioCarrito]";
            using (var connection = new SqlConnection(_GetConnection))
            {
                var usuarioCarrito = connection.Query<UsuarioCarrito>(sql).ToList();
                for (int i = 0; i < usuarioCarrito.Count; i++)
                {
                    list.Add(new UsuarioCarritoDTO()

                    {
                        Id_Carrito = usuarioCarrito[i].Id_Carrito,
                        Id_Usuario = usuarioCarrito[i].Id_Usuario,
                        Id_Usuario_Carrito = usuarioCarrito[i].Id_Usuario_Carrito

                    });
                }
                return list;
            }
        }

    }
}
