
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
  
  
    public IActionResult CheckLogin(string username, string password)
    {
        //aca se fija si es un usuario valido
        return View();
    }


    public IActionResult Registro()
    {
        //en el view vas a pedir user password
        return View();
    }

     public IActionResult ValidarRegistroUsuario()
    {
        //en el view vas a pedir user password
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
