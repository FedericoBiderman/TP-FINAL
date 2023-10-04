
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPLoginRegistro.Models;

namespace TPLoginRegistro.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public AccountController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Login()
    {
        //en el view vas a pedir user password
        return View();
    }
  
  
   [HttpPost] 
public IActionResult CheckLogin(string username, string contraseña)
{
    Usuario UsuarioEncontrado = BD.ObtenerUsuario(username);
    if (UsuarioEncontrado != null && UsuarioEncontrado.Contraseña == contraseña)
    {
        ViewBag.Usuario=UsuarioEncontrado;
        return View("Bienvenido");
    }
    else 
    {
        ViewBag.MensajeError = "Nombre de usuario o contraseña incorrectos";
        return View();
    }
}

    public IActionResult Registro()
    {
        //en el view vas a pedir user password
        return View();
    }

    /*recibe desdel formulario y guarda el usuario si no existia o muestra error si ya existia*/
   [HttpPost] public IActionResult ValidarRegistroUsuario(string username, string contraseña, string nombre, string apellido, int edad, int telefono, string email)
    {
        Usuario UsuarioYaExistentes = BD.ObtenerUsuario(username);

       if (UsuarioYaExistentes != null)
        {
            ViewBag.MensajeError = "Este nombre de usuario ya está en uso";
            return View();
        }

        Usuario nuevoUsuario = new Usuario(0, username, contraseña, "", "", 0, 0, "");

        BD.RegistrarUsuario(nuevoUsuario);

        return RedirectToAction("Login");
}


    public IActionResult OlvideContraseña()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CheckOlvideContraseña(string username, string ContraseñaNueva)
    {
        Usuario UsuariosSinContraseña = BD.ObtenerUsuario(username);

        if (UsuariosSinContraseña != null)
        {
            UsuariosSinContraseña.Contraseña = ContraseñaNueva;
            BD.ActualizarUsuario(UsuariosSinContraseña);

            ViewBag.MensajeExito = "La contraseña se restablecio de forma exitosa";
        }
        else
        {
            ViewBag.MensajeError = "No se ha encontrado a un usuario con ese nombre";
        }

        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}







