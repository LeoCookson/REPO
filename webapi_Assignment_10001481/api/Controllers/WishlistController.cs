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
   public class WishlistController : ControllerBase
   {

       private readonly DB_6215_19_S1 _context;

       public WishlistController(DB_6215_19_S1 context)
       {
           _context = context;
       }

         [HttpGet]
        public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishlist()
        {
            return await _context.Wishlist.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Wishlist>> GetWishlist(int id)
        {   
            Wishlist item = await _context.Wishlist.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Wishlist>> PostWishlist(Wishlist item)
        {
            _context.Wishlist.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
              nameof(GetWishlist), 
              item);
        }

        [HttpPut ("{id}")]
         public async Task<IActionResult> PutTodo (int id, Wishlist item) {
         if (id != item.Id) {
         return BadRequest ();
         }
         _context.Entry (item).State = EntityState.Modified;
         await _context.SaveChangesAsync ();
         return Content ("Wishlistupdated");
         }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishlist(int id)
        {
            Wishlist model = await _context.Wishlist.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            _context.Wishlist.Remove(model);
            await _context.SaveChangesAsync();

            return Content("Wishlist item removed");
        }
    }
}
