using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseWork_Server;
using Course_Lib.Models;

namespace CourseWork_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupTrainsController : ControllerBase
    {
        private readonly DBFitnessClubContext _context;

        public GroupTrainsController(DBFitnessClubContext context)
        {
            _context = context;
        }

        // GET: api/GroupTrains
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupTrain>>> GetGroupTrains()
        {
            if (_context.GroupTrains == null)
            {
                return NotFound();
            }
            return await _context.GroupTrains.ToListAsync();
        }

        // GET: api/GroupTrains/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupTrain>> GetGroupTrain(int id)
        {
            if (_context.GroupTrains == null)
            {
                return NotFound();
            }
            var groupTrain = await _context.GroupTrains.FindAsync(id);

            if (groupTrain == null)
            {
                return NotFound();
            }

            return groupTrain;
        }

        // PUT: api/GroupTrains/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupTrain(int id, GroupTrain groupTrain)
        {
            if (id != groupTrain.Id)
            {
                return BadRequest();
            }

            _context.Entry(groupTrain).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupTrainExists(id))
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

        // POST: api/GroupTrains
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("CreateGroupTraining")]
        public async Task<ActionResult<GroupTrain>> PostGroupTrain(GroupTrain groupTrain)
        {
            if (_context.GroupTrains == null)
            {
                return Problem("Entity set 'DBFitnessClubContext.GroupTrains'  is null.");
            }
            _context.GroupTrains.Add(groupTrain);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupTrain", new { id = groupTrain.Id }, groupTrain);
        }

        // DELETE: api/GroupTrains/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupTrain(int id)
        {
            if (_context.GroupTrains == null)
            {
                return NotFound();
            }
            var groupTrain = await _context.GroupTrains.FindAsync(id);
            if (groupTrain == null)
            {
                return NotFound();
            }

            _context.GroupTrains.Remove(groupTrain);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupTrainExists(int id)
        {
            return (_context.GroupTrains?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
