using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly EmployeeMasterContext _context;

        public EmployeeDetailsController(EmployeeMasterContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeMaster>>> GetEmployeeMasters()
        {
          if (_context.EmployeeMasters == null)
          {
              return NotFound();
          }
            return await _context.EmployeeMasters.ToListAsync();
        }

        // GET: api/EmployeeDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeMaster>> GetEmployeeMaster(int id)
        {
          if (_context.EmployeeMasters == null)
          {
              return NotFound();
          }
            var employeeMaster = await _context.EmployeeMasters.FindAsync(id);

            if (employeeMaster == null)
            {
                return NotFound();
            }

            return employeeMaster;
        }

        // PUT: api/EmployeeDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeMaster(int id, EmployeeMaster employeeMaster)
        {
            if (id != employeeMaster.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employeeMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeMasterExists(id))
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

        // POST: api/EmployeeDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeMaster>> PostEmployeeMaster(EmployeeMaster employeeMaster)
        {
          if (_context.EmployeeMasters == null)
          {
              return Problem("Entity set 'EmployeeMasterContext.EmployeeMasters'  is null.");
          }
            _context.EmployeeMasters.Add(employeeMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeMaster", new { id = employeeMaster.EmployeeId }, employeeMaster);
        }

        // DELETE: api/EmployeeDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeMaster(int id)
        {
            if (_context.EmployeeMasters == null)
            {
                return NotFound();
            }
            var employeeMaster = await _context.EmployeeMasters.FindAsync(id);
            if (employeeMaster == null)
            {
                return NotFound();
            }

            _context.EmployeeMasters.Remove(employeeMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeMasterExists(int id)
        {
            return (_context.EmployeeMasters?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
