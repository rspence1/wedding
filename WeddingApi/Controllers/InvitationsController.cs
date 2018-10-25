using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingApi.ModelsDBO;

namespace WeddingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationsController : ControllerBase
    {
        private readonly weddingContext _context;

        public InvitationsController(weddingContext context)
        {
            _context = context;
        }

        // GET: api/Invitations
        [HttpGet]
        public IEnumerable<Invitation> GetInvitation()
        {
            return _context.Invitation;
        }

        // GET: api/Invitations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvitation([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invitation = await _context.Invitation.FindAsync(id);

            if (invitation == null)
            {
                return NotFound();
            }

            return Ok(invitation);
        }

        // PUT: api/Invitations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvitation([FromRoute] Guid id, [FromBody] Invitation invitation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invitation.Id)
            {
                return BadRequest();
            }

            _context.Entry(invitation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvitationExists(id))
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

        // POST: api/Invitations
        [HttpPost]
        public async Task<IActionResult> PostInvitation([FromBody] Invitation invitation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Invitation.Add(invitation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvitation", new { id = invitation.Id }, invitation);
        }

        // DELETE: api/Invitations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvitation([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invitation = await _context.Invitation.FindAsync(id);
            if (invitation == null)
            {
                return NotFound();
            }

            _context.Invitation.Remove(invitation);
            await _context.SaveChangesAsync();

            return Ok(invitation);
        }

        private bool InvitationExists(Guid id)
        {
            return _context.Invitation.Any(e => e.Id == id);
        }
    }
}