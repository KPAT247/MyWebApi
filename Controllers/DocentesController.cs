using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Models;

namespace MyWebApi.Controllers;

// https://localhost:5343/api/Alumno
[ApiController]
[Route("api/[controller]")]
public class DocentesController : ControllerBase
{
    private readonly SqliteDbContext _db; 
    public DocentesController(SqliteDbContext db)
    {
        _db = db;
    }

     [HttpGet]
     public async Task<IEnumerable<Docentes>> Get()
     {
        // Obtener todos los alumnos
        var docentes = await _db.Docentes.ToListAsync();
        
        return docentes;
     }
     
     [HttpPost]
     public async Task<ActionResult<Docentes>> Post(Docentes docentes)
     {
        object Docentes = await _db.Docentes.AddAsync(docentes);
        await _db.SaveChangesAsync();

        return Ok(docentes);
     }

     [HttpGet("{id}")] 
   public async Task<ActionResult<Docentes>> FindDocenteById(int id)
   {
      // validar id
      if (id == 0)
      {
         return BadRequest();
      }

      
      var docentes = await GetDocentesById(id); 
      if (docentes is null)
      {
         return NotFound();
      }
      return Ok(docentes);
   }

   private Task<Docentes?> GetDocentesById(int id)
   {
      return Task.Run(() => _db.Docentes.Find(id));
   }

   [HttpPut("edit/(id)")] // https://localhost:7070/api/Alumnos/edit/1
   public async Task<IActionResult> UpdateDocente(int id, [FromBody] Docentes docenteDatosNuevos)
   {
      if (docenteDatosNuevos is null || id != docenteDatosNuevos.Id)
      {
         return BadRequest();
      }

      var docentes = await GetDocentesById(id);
      if (docentes is null)
      {
         return NotFound();
      }

      docentes.Id = docenteDatosNuevos.Id;
      docentes.nombres = docenteDatosNuevos.nombres;
      docentes.apellidos = docenteDatosNuevos.apellidos;

      _db.Docentes.Update(docentes);
      await _db.SaveChangesAsync();

      return NoContent();

   }

   [HttpDelete("delete/(id)")] // https://localhost:7070/api/Alumnos/delete/1
   public async Task<IActionResult> DeleteDocentes(int id)
   {
      if (id == 0)
      {
         return BadRequest();

      }

      var Docentes = await GetDocentesById(id);
      if(Docentes is null)
      {
         return NotFound();
      }

      _db.Docentes.Remove(Docentes);
      await _db.SaveChangesAsync();

      return NoContent();

   }
}