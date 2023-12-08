using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Models;

public class Carrera
{
    public int Id {get; set;}
    public string Nombre {get; set;} = null!;

    [NotMapped]
    public List<Alumno>? Alumnos {get; set;}
}