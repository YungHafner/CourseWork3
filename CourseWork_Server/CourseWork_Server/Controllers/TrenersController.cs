using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_Lib.Models;
using Course_Lib;

namespace CourseWork_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrenersController : ControllerBase
    {
        private readonly DBFitnessClubContext _context;

        public TrenersController(DBFitnessClubContext context)
        {
            _context = context;
        }

        // GET: api/Treners
        [HttpPost("GetAllTrenersWithImages")]
        public async Task<ActionResult<IEnumerable<Trener>>> GetAllTreners()
        {
            if (_context.Treners == null)
            {
                return NotFound();
            }

            var treners =  await _context.Treners.ToListAsync();
            treners.ForEach(s => s.TraningNavigation = _context.ImageTreners.Find(s.ImageTrenerId));
            return treners;
        }

        // GET: api/Treners/5
        [HttpPost("GetTrener")]
        public async Task<ActionResult<Trener>> GetTrener(int id)
        {
            if (_context.Treners == null)
            {
                return NotFound();
            }
            var trener = await _context.Treners.FindAsync(id);

            if (trener == null)
            {
                return NotFound();
            }

            return trener;
        }

        
        [HttpPost("EditTrener")]
        public async Task<IActionResult> PutTrener(Trener trener)
        {   
            try
            {
                _context.Entry(trener).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);

            }

            return Ok();
        }

        [HttpPost("AutorezationTrener")]
        public async Task<ActionResult<Trener>> AutorezationTrener([FromBody] AuthData trenerauth)
        {
            try
            {
                if (_context.Treners == null)
                {
                    return NotFound();
                }
                Trener trener = null;
                trener = _context.Treners.FirstOrDefault(a => a.TrenerLogin == trenerauth.Login
                && a.TrenerPassword == trenerauth.Password);
                if (trener == null)
                {
                    return NotFound();
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex);
            }
            return Ok();
            //return CreatedAtAction("CreateTrener", new { id = trener.Id, trenerName = trener.TrenerName, trenerType = trener.TrenerType, trenerDescription = trener.TrenerDescription, trenerLogin = trener.TrenerLogin, trenerPassword = trener.TrenerPassword }, trener);
        }

        // POST: api/Treners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Create_Trener")]
        public async Task<ActionResult<Trener>> PostTrener([FromBody]Trener trener)
        {
            try
            {
                if (_context.Treners == null)
                {
                    return NotFound();
                }
                _context.Treners.Add(trener);
                _context.SaveChanges();
                if (trener == null)
                {
                    return NotFound();
                }
            }
            catch(DbUpdateConcurrencyException ex)
            {
                return Ok(ex);
            }
            return Ok();    
            //return CreatedAtAction("CreateTrener", new { id = trener.Id, trenerName = trener.TrenerName, trenerType = trener.TrenerType, trenerDescription = trener.TrenerDescription, trenerLogin = trener.TrenerLogin, trenerPassword = trener.TrenerPassword }, trener);
        }

        // DELETE: api/Treners/5
        [HttpPost("Delete_Trener")]
        public async Task<IActionResult> DeleteTrener([FromBody]int id)
        {
            try
            {
                if (_context.Treners == null)
                {
                    return NotFound();
                }
                var trener = await _context.Treners.FindAsync(id);
                if (trener == null)
                {
                    return NotFound();
                }

                var treners = await _context.Treners.ToListAsync();
                treners.ForEach(s => s.TraningNavigation = _context.ImageTreners.Find(s.ImageTrenerId));

                //var img_trener = _context.ImageTreners.Find(trener.ImageTrenerId);

                // var treners = await _context.Treners.Include(t => t.TraningNavigation).ToListAsync();

                //_context.ImageTreners.Remove(img_trener);



                //_context.Treners.Remove(trener);
                //await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                return Ok(e);
            }

            return Ok();
        }

        private bool TrenerExists(int id)
        {
            return (_context.Treners?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
