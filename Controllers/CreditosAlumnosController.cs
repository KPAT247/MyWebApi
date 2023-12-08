using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Models;

namespace MyWebApi.Controllers;

// https://localhost:5343/api/Alumno
[ApiController]
[Route("api/[controller]")]
public class CreditosAlumnosController : ControllerBase
{
    private readonly SqliteDbContext _db; 
    public CreditosAlumnosController(SqliteDbContext db)
    {
        _db = db;
    }

     [HttpGet]
     public async Task<IEnumerable<Creditos>> Get()
     {
        // Obtener todos los alumnos
        var creditoalumnos = await _db.CreditosAlumnos.ToListAsync();
        
        return creditoalumnos;
     }
     
     [HttpPost]
     public async Task<ActionResult<Creditos>> Post(Creditos creditosAlumnos)
     {
        object creditoalumnos = await _db.CreditosAlumnos.AddAsync(creditosAlumnos);
        await _db.SaveChangesAsync();

        return Ok(creditoalumnos);
     }

     [HttpGet("{id}")] 
   public async Task<ActionResult<Creditos>> FindCreditosById(int id)
   {
      // validar id
      if (id == 0)
      {
         return BadRequest();
      }

      
      var creditoalumnos = await GetCreditosById(id); 
      if (creditoalumnos is null)
      {
         return NotFound();
      }
      return Ok(creditoalumnos);
   }

   private Task<Creditos?> GetCreditosById(int id)
   {
      return Task.Run(() => _db.CreditosAlumnos.Find(id));
   }

   [HttpPut("edit/(id)")] // https://localhost:7070/api/Alumnos/edit/1
   public async Task<IActionResult> UpdateCreditos(int id, [FromBody] Creditos creditosDatosNuevos)
   {
      if (creditosDatosNuevos is null || id != creditosDatosNuevos.Id)
      {
         return BadRequest();
      }

      var creditos = await GetCreditosById(id);
      if (creditos is null)
      {
         return NotFound();
      }

      creditos.Id = creditosDatosNuevos.Id;
      creditos.Descripcion = creditosDatosNuevos.Descripcion;
     
      _db.CreditosAlumnos.Update(creditos);
      await _db.SaveChangesAsync();

      return NoContent();

   }

   [HttpDelete("delete/(id)")] // https://localhost:7070/api/Alumnos/delete/1
   public async Task<IActionResult> DeleteCreditos(int id)
   {
      if (id == 0)
      {
         return BadRequest();

      }

      var creditos = await GetCreditosById(id);
      if(creditos is null)
      {
         return NotFound();
      }

      _db.CreditosAlumnos.Remove(creditos);
      await _db.SaveChangesAsync();

      return NoContent();

   }
}