using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Models;

public class Alumno
{
    public int Id { get; set; }
    public string Matricula { get; set; } = null!;
    public string  Nombres { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public int CarreraId { get; set; }

    [NotMapped]
    public Carrera? Carrera { get; set; }
}