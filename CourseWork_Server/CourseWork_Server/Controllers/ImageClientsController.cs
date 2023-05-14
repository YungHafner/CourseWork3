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
        [HttpPost("GetAllImages")]
        public async Task<ActionResult<IEnumerable<ImageClient>>> GetImageClients()
        {
            if (_context.ImageClients == null)
            {
                return NotFound();
            }
            return await _context.ImageClients.ToListAsync();
        }

        // GET: api/ImageClients/5
        [HttpPost("Get_Client/{id}")]
        public async Task<ActionResult<ImageClient>> GetImageClient(int id)
        {
            ImageClient imageClient;
            try
            {
                if (_context.ImageClients == null)
                {
                    return NotFound();
                }
                imageClient = await _context.ImageClients.FindAsync(id);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(imageClient);
        }

        [HttpPost("EditPhoto")]
        public async Task<ActionResult<ImageClient>> PutImageClient([FromBody]ImageClient imageClient)
        {
            try
            {
                _context.Entry(imageClient).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ImageClientExists(imageClient.Id))
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    throw;
                }
            }

            return imageClient;
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
