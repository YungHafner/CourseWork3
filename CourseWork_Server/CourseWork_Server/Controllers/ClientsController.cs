using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_Lib.Models;

namespace CourseWork_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly DBFitnessClubContext _context;

        public ClientsController(DBFitnessClubContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpPost("GetAll")]
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }
            var clients = await _context.Clients.ToListAsync();
            clients.ForEach(s => s.ImageClient = _context.ImageClients.Find(s.ImageClientId ));
            return clients;
        }

        // GET: api/Clients/5
        [HttpPost("GetClient")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("UpdateClient")]
        public async Task<IActionResult> PutClient([FromBody]Client client)
        {
            if(client.Id == 0) 
            {
                return NotFound();
            }
            try
            {
                _context.Entry(client).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }

            return Ok();
        }

        // POST: api/Clientsa

        [HttpPost("Create_Client")]
        public async Task<ActionResult<Client>> PostClient([FromBody] Client client)
        {
            try
            {
                if (_context.Clients == null)
                {
                    return NotFound();
                }
                if (client == null)
                {
                    return NotFound();
                }
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
            return Ok();
        }

        // DELETE: api/Clients/5
        [HttpPost("DeleteClient")]
        public async Task<IActionResult> DeleteClient([FromBody]int id)
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ClientExists(int id)
        {
            return (_context.Clients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
