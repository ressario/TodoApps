using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly TodoContext _context;

        public DetailsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Details
        // Get All Data with flag "IsDelete" = false
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Details>>> GetDetail()
        {
            return await _context.Details.Where(x=>x.IsDelete==false).ToListAsync();
        }

        // GET: api/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Details>> GetDetail(long id)
        {
            var detail = await _context.Details.FindAsync(id);

            if (detail == null)
            {
                return NotFound();
            }

            return detail;
        }

        // PUT: api/Details/5
        // Information: Edit todo data
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetail(long id, Details detail)
        {
            if (id != detail.ID)
            {
                return BadRequest();
            }

            detail.ModifiedBy = HttpContext.User.Identity.Name; ;
            detail.ModifiedDate = DateTime.Now;

            _context.Entry(detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailExists(id))
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

        // POST: api/Details (Create New Record)
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Details>> PostDetail(Details detail)
        {
            detail.ModifiedBy = HttpContext.User.Identity.Name;
            detail.ModifiedDate = DateTime.Now;

            _context.Details.Add(detail);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetail", new { id = detail.ID }, detail);
        }

        // POST: api/Details/5
        // Information: Delete here means set flag "IsDelete" into True
        [HttpPost("{id}")]
        public async Task<ActionResult<Details>> DeleteDetail(long id)
        {
            var detail = await _context.Details.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }

            detail.ModifiedBy = HttpContext.User.Identity.Name;
            detail.ModifiedDate = DateTime.Now;
            detail.IsDelete = true;

            //_context.Details.Remove(detail);
            _context.Details.Update(detail);
            await _context.SaveChangesAsync();

            return detail;
        }

        // Mark Todo Status As Done: api/Details/5
        // Information: Change Todo Status into Done
        [HttpPost("{id}")]
        public async Task<ActionResult<Details>> UpdateStatus(long id)
        {
            var detail = await _context.Details.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }

            detail.ModifiedBy = HttpContext.User.Identity.Name;
            detail.ModifiedDate = DateTime.Now;
            detail.Status = "Done";

            _context.Details.Update(detail);
            await _context.SaveChangesAsync();

            return detail;
        }

        // Mark Todo Status As Done: api/Details/5
        // Information: Change todo percent-completeness
        [HttpPost("{id}")]
        public async Task<ActionResult<Details>> SetTodoPercentComplete(long id, int? Percent)
        {
            var detail = await _context.Details.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }

            detail.ModifiedBy = HttpContext.User.Identity.Name;
            detail.ModifiedDate = DateTime.Now;
            detail.PercentCompleteness = Percent;

            _context.Details.Update(detail);
            await _context.SaveChangesAsync();

            return detail;
        }

        private bool DetailExists(long id)
        {
            return _context.Details.Any(e => e.ID == id);
        }
    }
}
