

public class Usuario
{
    public int IdUsuario { get; set; }
    public string Username { get; set; }
    public string Contraseña { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }
    public int Telefono { get; set; }
    public string Email { get; set; }

    public Usuario(int idUsuario, string username, string contraseña, string nombre, string apellido, int edad , int telefono, string email)
    {
        IdUsuario = idUsuario;
        Username = username;
        Contraseña = contraseña;
        Nombre = nombre;
        Apellido = apellido;
        Edad = edad;
        Telefono = telefono;
        Email = email;
    }
}