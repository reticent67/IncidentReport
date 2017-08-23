using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IncidentReport.Data;
using IncidentReport.Models;

namespace IncidentReport.Controllers
{
    [Produces("application/json")]
    [Route("api/Officer")]
    public class OfficerController : Controller
    {
        private readonly IRcontext _context;

        public OfficerController(IRcontext context)
        {
            _context = context;
        }

       // GET: api/Officer
        [HttpGet]
        public async Task<IActionResult> GetOfficers()
        {
            var officerList = await _context.Officers.ToListAsync();

            return Json(officerList);
        }

        // GET: api/Officer/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfficer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var officer = await _context.Officers.SingleOrDefaultAsync(m => m.OfficerID == id);

            if (officer == null)
            {
                return NotFound();
            }

            return Ok(officer);
        }

        // PUT: api/Officer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfficer([FromRoute] int id, [FromBody] Officer officer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != officer.OfficerID)
            {
                return BadRequest();
            }

            _context.Entry(officer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficerExists(id))
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

        // POST: api/Officer
        [HttpPost]
        public async Task<IActionResult> CreateOfficer([FromBody] Officer officer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Officers.Add(officer);
            await _context.SaveChangesAsync();

            return Json("OK");
            //return CreatedAtAction("GetOfficer", new { id = officer.OfficerID }, officer);
        }

        // DELETE: api/Officer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfficer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var officer = await _context.Officers.SingleOrDefaultAsync(m => m.OfficerID == id);
            if (officer == null)
            {
                return NotFound();
            }

            _context.Officers.Remove(officer);
            await _context.SaveChangesAsync();

            return Ok(officer);
        }

        private bool OfficerExists(int id)
        {
            return _context.Officers.Any(e => e.OfficerID == id);
        }
    }
}