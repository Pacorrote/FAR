using Dapper;
using FAR.Models;
using System.Data.SqlClient;

namespace FAR.Commands
{
    public class UsuariosRolCommand : IUsuariosRolCommand
    {
        private readonly string CONNECTIONSTRING;

        public UsuariosRolCommand(string CONNECTIONSTRING)
        {
            this.CONNECTIONSTRING = CONNECTIONSTRING;
        }
        public bool ModifyUsuariosRol(UsuarioRol usuarioRol)
        {
            string sql = @"UPDATE [dbo].[Usuarios]
                                    SET [Tipo_Usuario] = @Tipo_Usuario
                                    WHERE Id_Rol = " + usuarioRol.Id_Rol + "; GO";
            try
            {
                using (var connection = new SqlConnection(CONNECTIONSTRING))
                {
                    var affectedRows = connection.Execute(sql, usuarioRol);
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

        public UsuarioRol RemoveUsuariosRol(int id)
        {
            UsuarioRol usuarioRol;
            string sql = "Select * from [dbo].[UsuarioRol] where Id_Rol = " + id + ";";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                usuarioRol = connection.Query<UsuarioRol>(sql).FirstOrDefault();
            }
            sql = "DELETE FROM [dbo].[UsuarioRol] WHERE Id_Rol = " + id + ";";
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                var rowAffected = connection.Execute(sql);
            }
            return usuarioRol;
        }

        public bool SaveUsuariosRol(UsuarioRol newUR)
        {
            string sql = @"INSERT INTO [dbo].[Usuarios]
                                   ([Tipo_Usuario])
                             VALUES
                                   (@Tipo_Usuario)
                        GO
                        ";
            try
            {
                using (var connection = new SqlConnection(CONNECTIONSTRING))
                {
                    var affectedRows = connection.Execute(sql, newUR);
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
