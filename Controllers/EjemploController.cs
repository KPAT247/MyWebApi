using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EjemploController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Hola compas desde una web api en asp.net";
    }
}