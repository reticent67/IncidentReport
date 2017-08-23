using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IncidentReport.Data;
using IncidentReport.Models;

namespace IncidentReport.Controllers
{
    [Produces("application/json")]
    [Route("api/Report")]
    public class ReportController : Controller
    {
        private readonly IRcontext _context;

        public ReportController(IRcontext context)
        {
            _context = context;
        }

        // GET: api/Report
        [HttpGet]
        public IEnumerable<InvestigativeReport> GetInvestigativeReports()
        {
            return _context.InvestigativeReports;
        }

        // GET: api/Report/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvestigativeReport([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var investigativeReport = await _context.InvestigativeReports.SingleOrDefaultAsync(m => m.ReportID == id);

            if (investigativeReport == null)
            {
                return NotFound();
            }

            return Ok(investigativeReport);
        }

        // PUT: api/Report/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestigativeReport([FromRoute] int id, [FromBody] InvestigativeReport investigativeReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != investigativeReport.ReportID)
            {
                return BadRequest();
            }

            _context.Entry(investigativeReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestigativeReportExists(id))
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

        // POST: api/Report
        [HttpPost]
        public async Task<IActionResult> PostInvestigativeReport([FromBody] InvestigativeReport investigativeReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InvestigativeReports.Add(investigativeReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvestigativeReport", new { id = investigativeReport.ReportID }, investigativeReport);
        }

        // DELETE: api/Report/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvestigativeReport([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var investigativeReport = await _context.InvestigativeReports.SingleOrDefaultAsync(m => m.ReportID == id);
            if (investigativeReport == null)
            {
                return NotFound();
            }

            _context.InvestigativeReports.Remove(investigativeReport);
            await _context.SaveChangesAsync();

            return Ok(investigativeReport);
        }

        private bool InvestigativeReportExists(int id)
        {
            return _context.InvestigativeReports.Any(e => e.ReportID == id);
        }
    }
}