using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApi.Models;

public class Creditos
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
    public int AlumnoId { get; set; }

    [NotMapped]
    public Alumno? Alumno { get; set; }
}