using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Models;

public class Tutores
{
    public int Id { get; set; }
    public string matricula { get; set; } = null!;
    public string  nombres { get; set; } = null!;
    public string apellidos { get; set; } = null!;
    public int CarreraId { get; set; }

    [NotMapped]
   public List<Alumno>? Alumnos {get; set;}
   
   [NotMapped]
    public Carrera? Carrera { get; set; }
}
