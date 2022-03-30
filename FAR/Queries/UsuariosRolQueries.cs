using Dapper;
using FAR.DTOs;
using FAR.Models;
using System.Data.SqlClient;

namespace FAR.Queries
{
    public class UsuariosRolQueries : IUsuariosRolQueries
    {
        private readonly string CONNECTIONSTRING;

        public UsuariosRolQueries(string CONNECTIONSTRING)
        {
            this.CONNECTIONSTRING = CONNECTIONSTRING;
        }

        public UsuariosRolDTO FindByID(uint id)
        {
            throw new NotImplementedException();
        }

        public List<UsuariosRolDTO> GetAll()
        {
            List<UsuariosRolDTO> list = new List<UsuariosRolDTO>();
            string sql = "Select * from [dbo].[UsuarioRol]";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                var usuarios = connection.Query<UsuarioRol>(sql).ToList();
                for (int i = 0; i < usuarios.Count; i++)
                {
                    list.Add(new UsuariosRolDTO());
                }
            }
            return list;
        }
    }
}
