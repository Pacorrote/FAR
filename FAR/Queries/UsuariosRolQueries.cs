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
            string sql = "Select * from [dbo].[UsuarioRol] where Id_Rol = " + id + ";";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                var usuarioRol = connection.Query<UsuarioRol>(sql).FirstOrDefault();
                return new UsuariosRolDTO
                {
                    Id_Rol = usuarioRol.Id_Rol,
                    Tipo_Usuario = usuarioRol.Tipo_Usuario
                };
            }
        }

        public List<UsuariosRolDTO> GetAll()
        {
            List<UsuariosRolDTO> list = new List<UsuariosRolDTO>();
            string sql = "Select * from [dbo].[UsuarioRol]";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                var usuarioRol = connection.Query<UsuarioRol>(sql).ToList();
                for (int i = 0; i < usuarioRol.Count; i++)
                {
                    list.Add(new UsuariosRolDTO()
                    {
                        Id_Rol = usuarioRol[i].Id_Rol,
                        Tipo_Usuario = usuarioRol[i].Tipo_Usuario
                    });
                }
            }
            return list;
        }
    }
}
