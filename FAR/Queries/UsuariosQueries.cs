using Dapper;
using FAR.DTOs;
using FAR.Models;
using System.Data.SqlClient;

namespace FAR.Queries
{
    public class UsuariosQueries : IUsuariosQueries
    {
        private readonly string CONNECTIONSTRING;

        public UsuariosQueries(string CONNECTIONSTRING)
        {
            this.CONNECTIONSTRING = CONNECTIONSTRING;
        }

        public UsuariosDTO FindByID(uint id)
        {
            throw new NotImplementedException();
        }

        public List<UsuariosDTO> GetAll()
        {
            List<UsuariosDTO> list = new List<UsuariosDTO>();
            string sql = "Select * from [dbo].[Usuarios]";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                var usuarios = connection.Query<Usuarios>(sql).ToList();
                for (int i = 0; i < usuarios.Count; i++)
                {
                    list.Add(new UsuariosDTO());
                }
            }
            return list;
        }
    }
}
