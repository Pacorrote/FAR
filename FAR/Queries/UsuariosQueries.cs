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
            string sql = "Select * from [dbo].[Usuarios] where Id_Usuario = " + id + ";";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                var usuario = connection.Query<Usuarios>(sql).FirstOrDefault();
                return new UsuariosDTO
                {
                    Email = usuario.Email,
                    Contrasena = usuario.Contrasena,
                    Calle = usuario.Calle,
                    Apellidos = usuario.Apellidos,
                    Fecha_Nacimiento = usuario.Fecha_Nacimiento,
                    Id_Localidad = usuario.Id_Localidad,
                    Id_Rol = usuario.Id_Rol,
                    Id_Usuario = usuario.Id_Usuario,
                    Nombre = usuario.Nombre,
                    Telefono = usuario.Telefono,
                    Username = usuario.Username,
                };
            }
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
                    list.Add(new UsuariosDTO()

                    {
                        Email = usuarios[i].Email,
                        Contrasena = usuarios[i].Contrasena,
                        Calle = usuarios[i].Calle,
                        Apellidos = usuarios[i].Apellidos,
                        Fecha_Nacimiento = usuarios[i].Fecha_Nacimiento,
                        Id_Localidad = usuarios[i].Id_Localidad,
                        Id_Rol = usuarios[i].Id_Rol,
                        Id_Usuario = usuarios[i].Id_Usuario,
                        Nombre = usuarios[i].Nombre,
                        Telefono = usuarios[i].Telefono,
                        Username = usuarios[i].Username,

                    });
                }
            }
            return list;
        }
    }
}
