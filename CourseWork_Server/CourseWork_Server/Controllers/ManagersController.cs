using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Course_Lib.Models;
using Course_Lib;

namespace CourseWork_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly DBFitnessClubContext _context;

        public ManagersController(DBFitnessClubContext context)
        {
            _context = context;
        }

        // GET: api/Managers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> GetManagers()
        {
            if (_context.Managers == null)
            {
                return NotFound();
            }
            return await _context.Managers.ToListAsync();
        }

        // GET: api/Managers/5
        [HttpPost("CreateRegistrationManager")]
        public async Task<ActionResult<Manager>> GetManager(Manager manager)
        {
            if (_context.Managers == null)
            {
                return NotFound();
            }

            _context.Managers.Add(manager);
            await _context.SaveChangesAsync();

            if (manager == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("SearchOne")]
        public async Task<ActionResult<Manager>> PostManager(AuthData auth)
        {
            if (_context.Managers == null)
            {
                return NotFound();
            }
            Manager manager = null;
            try
            {
                manager = await _context.Managers.FirstOrDefaultAsync(a => a.LoginManager == auth.Login
                && a.PasswordManager == auth.Password);
                if (manager == null)
                {
                    return NotFound();
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            return manager;
        }

       

        private bool ManagerExists(int id)
        {
            return (_context.Managers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
