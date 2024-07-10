using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostgreSql_Basic_Api.Models;

namespace PostgreSql_Basic_Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class MoviesController : ControllerBase
   {
      private readonly AppDbContext _context;

      public MoviesController(AppDbContext context)
      {
         _context = context;
      }



      [HttpGet]
      public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
      {
         return await _context.Movies.ToListAsync();
      }

      [HttpGet("{id}")]
      public async Task<ActionResult<Movie>> GetMovies(int id)
      {
         var Movies = await _context.Movies.FindAsync(id);
         if (Movies == null)
         {
            return NotFound();
         }
         return Movies;
      }

      [HttpPost]
      public async Task<ActionResult<Movie>> PostMovies(Movie movie)
      {
         _context.Movies.Add(movie);
         await _context.SaveChangesAsync();
         return CreatedAtAction("GetMovies", new { id = movie.Id }, movie);
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> PutMovies(int id, Movie movie)
      {
         if (id != movie.Id)
         {
            return BadRequest();
         }
         _context.Entry(movie).State = EntityState.Modified;
         try
         {
            await _context.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException)
         {
            if (!MovieExists(id))
            {
               return NotFound();
            }
            else
            {
               throw;
            }
         }

         return NoContent();
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteMovie(int id)
      {
         var Movie = await _context.Movies.FindAsync(id);
         if (Movie == null)
         {
            return NotFound();
         }
         _context.Movies.Remove(Movie);
         await _context.SaveChangesAsync();
         return NoContent();
      }

      private bool MovieExists(int id)
      {
         return _context.Movies.Any(e => e.Id == id);
      }

   }
}
