using System;
using Dapper;
using System.Data;
using System.Data.SqlClient;

public static class BD
{
    private static string _connectionString = "Server=localhost;DataBase=TPLogin;Trusted_Connection=True;";

    public static Usuario ObtenerUsuario(string username){
        string sql = "SELECT * FROM Usuario WHERE Username = @username";
        using (SqlConnection db = new SqlConnection(_connectionString)){
            return db.QueryFirstOrDefault<Usuario>(sql, new {username});
        }
    }

    public static void RegistrarUsuario(Usuario user){
        string sql = "INSERT INTO Usuario (Username, Contraseña, Nombre, Apellido, Email, Edad, Telefono, IdUsuario) VALUES (@Username, @Contraseña, @Nombre, @Apellido, @Email, @Edad, @Telefono, @IdUsuario)";
        using (SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {user.Username, user.Contraseña, user.Nombre, user.Apellido, user.Email, user.Edad, user.Telefono, user.IdUsuario,});
        }
    }
    //necesidades del login, registr y oo
}