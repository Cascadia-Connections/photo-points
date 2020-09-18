using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using photo_points.Models;

namespace photo_points.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapturesController : ControllerBase
    {
        private readonly PhotoDataContext _context;

        public CapturesController(PhotoDataContext context)
        {
            _context = context;
        }

        // GET: api/Captures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Capture>>> GetCaptures()
        {
            return await _context.Captures
                .Include(c => c.User)
                .Include(c => c.Datas)
                .Include(c => c.PhotoPoint)
                .Include(c => c.Tags)
                .ToListAsync();
        }

        // GET: api/Captures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Capture>> GetCapture(long id)
        {
            var captures = await _context.Captures
                .Include(c => c.User)
                .Include(c => c.Datas)
                .Include(c => c.PhotoPoint)
                .Include(c => c.Tags)
                .ToListAsync();

            Capture capture = new Capture { }; 
            capture = captures.Where(c => c.CaptureId == id).FirstOrDefault();
                
            if (capture == null)
            {
                return NotFound();
            }

            return capture;
        }

        // PUT: api/Captures/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCapture(long id, Capture capture)
        {
            if (id != capture.CaptureId)
            {
                return BadRequest();
            }

            _context.Entry(capture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaptureExists(id))
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

        // POST: api/Captures
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Capture>> PostCapture(Capture capture)
        {
            _context.Captures.Add(capture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCapture", new { id = capture.CaptureId }, capture);
        }

        // DELETE: api/Captures/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Capture>> DeleteCapture(long id)
        {
            var capture = await _context.Captures.FindAsync(id);
            if (capture == null)
            {
                return NotFound();
            }

            _context.Captures.Remove(capture);
            await _context.SaveChangesAsync();

            return capture;
        }

        private bool CaptureExists(long id)
        {
            return _context.Captures.Any(e => e.CaptureId == id);
        }
    }
}
