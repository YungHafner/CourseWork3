using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_Lib.Models;

namespace CourseWork_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageClientsController : ControllerBase
    {
        private readonly DBFitnessClubContext _context;

        public ImageClientsController(DBFitnessClubContext context)
        {
            _context = context;
        }

        // GET: api/ImageClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageClient>>> GetImageClients()
        {
            if (_context.ImageClients == null)
            {
                return NotFound();
            }
            return await _context.ImageClients.ToListAsync();
        }

        // GET: api/ImageClients/5
        [HttpPost("Get_Client")]
        public async Task<ActionResult<ImageClient>> GetImageClient(int id)
        {
            if (_context.ImageClients == null)
            {
                return NotFound();
            }
            var imageClient = await _context.ImageClients.FindAsync(id);

            if (imageClient == null)
            {
                return NotFound();
            }

            return imageClient;
        }

        [HttpPut("EditPhoto")]
        public async Task<IActionResult> PutImageClient(int id, ImageClient imageClient)
        {
            if (id != imageClient.Id)
            {
                return BadRequest();
            }

            _context.Entry(imageClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageClientExists(id))
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

        [HttpPost("CreateImage_Client")]
        public async Task<ActionResult<ImageClient>> PostImageClient(ImageClient imageClient)
        {
            if (_context.ImageClients == null)
            {
                return NotFound();
            }
            _context.ImageClients.Add(imageClient);
            await _context.SaveChangesAsync();

            return imageClient;
        }

        // DELETE: api/ImageClients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageClient(int id)
        {
            if (_context.ImageClients == null)
            {
                return NotFound();
            }
            var imageClient = await _context.ImageClients.FindAsync(id);
            if (imageClient == null)
            {
                return NotFound();
            }

            _context.ImageClients.Remove(imageClient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageClientExists(int id)
        {
            return (_context.ImageClients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
