using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_Lib.Models;

namespace CourseWork_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageTrenersController : ControllerBase
    {
        private readonly DBFitnessClubContext _context;

        public ImageTrenersController(DBFitnessClubContext context)
        {
            _context = context;
        }

        // GET: api/ImageTreners
        [HttpPost("GetAllImages")]
        public async Task<ActionResult<IEnumerable<ImageTrener>>> GetImageTreners()
        {
            if (_context.ImageTreners == null)
            {
                return NotFound();
            }
            return await _context.ImageTreners.ToListAsync();
        }

        // GET: api/ImageTreners/5
        [HttpPost("GetTrenersImage/{id}")]
        public async Task<ActionResult<ImageTrener>> GetImageTrener(int id)
        {
            if (id != 0)
            {
                if (_context.ImageTreners == null)
                {
                    return NotFound();
                }
                var imageTrener = await _context.ImageTreners.FindAsync(id);

                if (imageTrener == null)
                {
                    return NotFound();
                }

                return Ok(imageTrener);
            }
            else
            {
                return BadRequest();
            }
        }
        // PUT: api/ImageTreners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageTrener(int id, ImageTrener imageTrener)
        {
            if (id != imageTrener.Id)
            {
                return BadRequest();
            }

            _context.Entry(imageTrener).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Ok(ex);
            }

            return NoContent();
        }

        // POST: api/ImageTreners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("EditPhotoForTrener")]
        public async Task<ActionResult<ImageTrener>> PostImageTrener(ImageTrener imageTrener)
        {
            try
                { 
                if (_context.ImageTreners == null)
                {
                    return NotFound();
                }
                _context.ImageTreners.Add(imageTrener);
                await _context.SaveChangesAsync();
                if(imageTrener == null)
                {
                    return NotFound();
                }
            }
            catch(DbUpdateException ex)
            {
                return Ok(ex.Message);
            }
            return imageTrener;
            //return CreatedAtAction("GetImageTrener", new { id = imageTrener.Id }, imageTrener);
        }

        // DELETE: api/ImageTreners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageTrener(int id)
        {
            if (_context.ImageTreners == null)
            {
                return NotFound();
            }
            var imageTrener = await _context.ImageTreners.FindAsync(id);
            if (imageTrener == null)
            {
                return NotFound();
            }

            _context.ImageTreners.Remove(imageTrener);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageTrenerExists(int id)
        {
            return (_context.ImageTreners?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
