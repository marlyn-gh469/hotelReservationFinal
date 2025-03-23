using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelReservationFinal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationFinal.Data;

namespace HotelReservationFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RoomCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RoomCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomCategories>>> GetRoomCategories()
        {
            return await _context.RoomCategories.ToListAsync();
        }

        // GET: api/RoomCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomCategories>> GetRoomCategory(int id)
        {
            var roomCategory = await _context.RoomCategories.FindAsync(id);

            if (roomCategory == null)
            {
                return NotFound();
            }

            return roomCategory;
        }

        // POST: api/RoomCategories
        [HttpPost]
        public async Task<ActionResult<RoomCategories>> PostRoomCategory(RoomCategories roomCategory)
        {
            _context.RoomCategories.Add(roomCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRoomCategory), new { id = roomCategory.CategoryId }, roomCategory);
        }

        // PUT: api/RoomCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomCategory(int id, RoomCategories roomCategory)
        {
            if (id != roomCategory.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(roomCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.RoomCategories.Any(e => e.CategoryId == id))
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

        // DELETE: api/RoomCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomCategory(int id)
        {
            var roomCategory = await _context.RoomCategories.FindAsync(id);
            if (roomCategory == null)
            {
                return NotFound();
            }

            _context.RoomCategories.Remove(roomCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
