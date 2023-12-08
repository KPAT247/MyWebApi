using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Models;

public class Docentes
{
    public int Id { get; set; }
    public int NumeroDeTrabajador { get; set; }
    public string nombres { get; set; } = null!;
    public string apellidos { get; set; } = null!;
    public int CarreraId { get; set; }

    [NotMapped]
    public Carrera? Carrera { get; set; }
}