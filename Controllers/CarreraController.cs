using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Models;

namespace MyWebApi.Controllers;

// https://localhost:5343/api/Alumno
[ApiController]
[Route("api/[controller]")]
public class CarreraController : ControllerBase
{
    private readonly SqliteDbContext _db; 
    public CarreraController(SqliteDbContext db)
    {
        _db = db;
    }

     [HttpGet]
     public async Task<IEnumerable<Carrera>> Get()
     {
        // Obtener todos los alumnos
        var carrera = await _db.Carreras.ToListAsync();
        
        return carrera;
     }
     
     [HttpPost]
     public async Task<ActionResult<Alumno>> Post(Carrera carrera)
     {
        await _db.Carreras.AddAsync(carrera);
        await _db.SaveChangesAsync();

        return Ok(carrera);
     }

     [HttpGet("{id}")] 
   public async Task<ActionResult<Carrera>> FindCarreraById(int id)
   {
      // validar id
      if (id == 0)
      {
         return BadRequest();
      }
 
      var carrera = await GetCarreraById(id); 
      if (carrera is null)
      {
         return NotFound();
      }
      return Ok(carrera);
   }

   private Task<Carrera?> GetCarreraById(int id)
   {
      return Task.Run(() => _db.Carreras.Find(id));
   }

   [HttpPut("edit/(id)")] // https://localhost:7070/api/Alumnos/edit/1
   public async Task<IActionResult> UpdateCarrera(int id, [FromBody] Carrera carreraDatosNuevos)
   {
      if (carreraDatosNuevos is null || id != carreraDatosNuevos.Id)
      {
         return BadRequest();
      }

      var carrera = await GetCarreraById(id);
      if (carrera is null)
      {
         return NotFound();
      }

      carrera.Id = carreraDatosNuevos.Id;
      carrera.Nombre = carreraDatosNuevos.Nombre;

      _db.Carreras.Update(carrera);
      await _db.SaveChangesAsync();

      return NoContent();

   }

   [HttpDelete("delete/(id)")] // https://localhost:7070/api/Alumnos/delete/1
   public async Task<IActionResult> DeleteCarrera(int id)
   {
      if (id == 0)
      {
         return BadRequest();

      }

      var carrera = await GetCarreraById(id);
      if(carrera is null)
      {
         return NotFound();
      }

      _db.Carreras.Remove(carrera);
      await _db.SaveChangesAsync();

      return NoContent();

   }
}