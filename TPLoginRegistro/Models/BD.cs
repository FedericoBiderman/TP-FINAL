using Dapper;
using System.Data.SqlClient;

public static class BD
{
    private static string _connectionString = "Server=localhost;DataBase=TPLogin;Trusted_Connection=True;";

    /*Recibe el username y devuelve el usuario si existe*/
    public static Usuario ObtenerUsuario(string username){
        string sql = "SELECT * FROM Usuario WHERE Username = @username";
        using (SqlConnection db = new SqlConnection(_connectionString)){
            return db.QueryFirstOrDefault<Usuario>(sql, new {username});
        }
    }

    /*recibe un usuario y inserta todos los valores*/
    public static void RegistrarUsuario(Usuario usuario){
        string sql = "INSERT INTO Usuario (Username, Contraseña, Nombre, Apellido, Email, Edad, Telefono) VALUES (@Username, @Contraseña, @Nombre, @Apellido, @Email, @Edad, @Telefono)";
        using (SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {usuario.Username, usuario.Contraseña, usuario.Nombre, usuario.Apellido, usuario.Email, usuario.Edad, usuario.Telefono});
        }
    }

    
    
    /*actualiza la contraseña de un usuario*/
    public static void ActualizarUsuario(Usuario usuario)
    {
        string SQL = "UPDATE Usuario SET Contraseña = @Contraseña WHERE Username = @username";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(SQL, usuario);
        }
    }
}
