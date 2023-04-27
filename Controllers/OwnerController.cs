using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cSharpApi.Models;

namespace cSharpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly MyFirstAPIDBContext _context;

        public OwnerController(MyFirstAPIDBContext context)
        {
            _context = context;

        }

        // GET: api/Owner
        [HttpGet]
        public async Task<ActionResult<Response>> GetOwners()
        {

            var response = new Response();
            response.statusCode = 200;
            response.statusDescription = "Success, returning all owners";

            var owners = await _context.Owners.ToListAsync();
            response.owners.AddRange(owners);
            return response;
        }

        // GET: api/Owner/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetOwner(int id)
        {
            var owner = await _context.Owners.FindAsync(id);


            var response = new Response();



            if (owner == null)
            {

                response.statusCode = 404;
                response.statusDescription = "Not Found, owner id " + id + " returns null";
                return NotFound(response);
            }
            else
            {

                response.statusCode = 200;
                response.statusDescription = "Success, found owner with id " + id;
                response.owners.Add(owner);
                return Ok(response);
            }


        }

        // POST: api/Owner
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostOwner(Owner owner)
        {
            var response = new Response();
            var existingOwner = await _context.Owners.FirstOrDefaultAsync(o => o.PhoneNumber == owner.PhoneNumber);
            if (existingOwner != null)
            {
                response.statusCode = 400;
                response.statusDescription = "Error, owner with phone number " + owner.PhoneNumber + " already exists";
                return BadRequest(response);

            }

            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();

            response.statusCode = 201;
            response.statusDescription = "Success, created new owner with id " + owner.OwnerId;
            response.owners.Add(owner);


            return CreatedAtAction("GetOwner", new { id = owner.OwnerId }, response);
        }

        // DELETE: api/Owner/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            var owner = await _context.Owners.FirstOrDefaultAsync(c => c.OwnerId == id);
            var response = new Response();

            if (owner == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Nothing deleted, owner id " + id + " not found";
                return NotFound(response);
            }

            _context.Owners.Remove(owner);


            await _context.SaveChangesAsync();
            response.statusCode = 200;
            response.statusDescription = "Succesfully deleted owner with id " + id;

            return Ok(response);
        }

        private bool OwnerExists(int id)
        {
            return _context.Owners.Any(e => e.OwnerId == id);
        }
    }
}