using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class MoviesController : ControllerBase
   {

       private readonly DB_6215_19_S1 _context;

       public MoviesController(DB_6215_19_S1 context)
       {
           _context = context;
       }

         [HttpGet]
        public async Task<ActionResult<IEnumerable<Movies>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movies>> GetMovies(int id)
        {   
            Movies item = await _context.Movies.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Movies>> Post(Movies item)
        {
            _context.Movies.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
              nameof(GetMovies), 
              item);
        }

        [HttpPut ("{id}")]
         public async Task<IActionResult> PutTodo (int id, Movies item) {
         if (id != item.Id) {
         return BadRequest ();
         }
         _context.Entry (item).State = EntityState.Modified;
         await _context.SaveChangesAsync ();
         return Content ("Movie updated");
         }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovies(short id)
        {
            Movies model = await _context.Movies.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(model);
            await _context.SaveChangesAsync();

            return Content("Movie removed");
        }
    }
}

    
   