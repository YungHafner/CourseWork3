using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_Lib.Models;

namespace CourseWork_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbonimentsController : ControllerBase
    {
        private readonly DBFitnessClubContext _context;

        public AbonimentsController(DBFitnessClubContext context)
        {
            _context = context;
        }

        [HttpPost("GetAllAboniments")]
        public async Task<ActionResult<IEnumerable<Aboniment>>> GetAboniments()
        {
            if (_context.Aboniments == null)
            {
                return NotFound();
            }
            return await _context.Aboniments.ToListAsync();
        }

        [HttpPost("GetAbonement")]
        public async Task<ActionResult<Aboniment>> GetAboniment(int id)
        {
            if (_context.Aboniments == null)
            {
                return NotFound();
            }
            var aboniment = await _context.Aboniments.FindAsync(id);

            if (aboniment == null)
            {
                return NotFound();
            }

            return aboniment;
        }

        [HttpPost("CreateAbonement")]
        public async Task<ActionResult<Aboniment>> PostAboniment([FromBody] Aboniment aboniment)
        {
            if (_context.Aboniments == null)
            {
                return NotFound();
            }
            _context.Aboniments.Add(aboniment);
            _context.SaveChanges();

            if (aboniment == null)
            {
                return NotFound();
            }

            return aboniment;
        }

        [HttpPost("DeleteAbonement")]
        public async Task<IActionResult> DeleteAboniment([FromBody]int id)
        {
            if (_context.Aboniments == null)
            {
                return NotFound();
            }
            var aboniment = await _context.Aboniments.FindAsync(id);
            if (aboniment == null)
            {
                return NotFound();
            }

            _context.Aboniments.Remove(aboniment);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool AbonimentExists(int id)
        {
            return (_context.Aboniments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
