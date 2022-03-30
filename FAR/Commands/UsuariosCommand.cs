using Dapper;
using FAR.Models;
using System.Data.SqlClient;

namespace FAR.Commands
{
    public class UsuariosCommand : IUsuariosCommand
    {
        private readonly string CONNECTIONSTRING;

        public UsuariosCommand(string CONNECTIONSTRING)
        {
            this.CONNECTIONSTRING = CONNECTIONSTRING;
        }

        public bool ModifyUsuariosRol(Usuarios usuario)
        {
            string sql = @"UPDATE [dbo].[Usuarios]
                                    SET [Nombre] = @Nombre
                                        ,[Apellidos] = @Apellidos
                                        ,[Telefono] = @Telefono
                                        ,[Email] = @Email
                                        ,[Calle] = @Calle
                                        ,[Id_Localidad] = @Id_Localidad
                                        ,[Fecha_Nacimiento] = @Fecha_Nacimiento
                                        ,[Contrasena] = @Contrasena
                                        ,[Username] = @Username
                                        ,[Id_Rol] = @Id_Rol
                                    WHERE Id_Usuario = " + usuario.Id_Usuario + "; GO";
            try
            {
                using (var connection = new SqlConnection(CONNECTIONSTRING))
                {
                    var affectedRows = connection.Execute(sql, usuario);
                    if (affectedRows > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Usuarios RemoveUsuariosRol(uint id)
        {
            Usuarios usuario;
            string sql = "Select * from [dbo].[Usuarios] where Id_Usuario = " + id + ";";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                usuario = connection.Query<Usuarios>(sql).FirstOrDefault();
            }
            sql = "DELETE FROM [dbo].[Usuarios] WHERE Id_Usuario = " + id + ";";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                var rowAffected = connection.Execute(sql);
            }
            return usuario;
        }

        public bool SaveProductoCarrito(Usuarios newUsuario)
        {
            string sql = @"INSERT INTO [dbo].[Usuarios]
                                   ([Nombre]
                                   ,[Apellidos]
                                   ,[Telefono]
                                   ,[Email]
                                   ,[Calle]
                                   ,[Id_Localidad]
                                   ,[Fecha_Nacimiento]
                                   ,[Contrasena]
                                   ,[Username]
                                   ,[Id_Rol])
                             VALUES
                                   (@Nombre
                                   ,@Apellidos
                                   ,@Telefono
                                   ,@Email
                                   ,@Calle
                                   ,@Id_Localidad
                                   ,@Fecha_Nacimiento
                                   ,@Contrasena
                                   ,@Username
                                   ,@Id_Rol)
                        GO
                        ";
            try
            {
                using (var connection = new SqlConnection(CONNECTIONSTRING))
                {
                    var affectedRows = connection.Execute(sql, newUsuario);
                    if (affectedRows > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
