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
    public class PetController : ControllerBase
    {
        private readonly MyFirstAPIDBContext _context;

        public PetController(MyFirstAPIDBContext context)
        {
            _context = context;

        }

        // GET: api/Pet
        [HttpGet]
        public async Task<ActionResult<Response>> GetPets()
        {

            var response = new Response();
            response.statusCode = 200;
            response.statusDescription = "Success, returning all pets";

            var pets = await _context.Pets.ToListAsync();
            response.pets.AddRange(pets);
            return response;
        }

        // GET: api/Pet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetPet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);


            var response = new Response();



            if (pet == null)
            {

                response.statusCode = 404;
                response.statusDescription = "Not Found, pet id " + id + " returns null";
                return NotFound(response);
            }
            else
            {

                response.statusCode = 200;
                response.statusDescription = "Success, found pet with id " + id;
                response.pets.Add(pet);
                return Ok(response);
            }


        }

        // POST: api/Owner
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostPet(Pet pet)
        {
            var response = new Response();

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            response.statusCode = 201;
            response.statusDescription = "Success, created new pet with id " + pet.PetId;
            response.pets.Add(pet);


            return CreatedAtAction("GetPet", new { id = pet.PetId }, response);
        }

        // DELETE: api/Pet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await _context.Pets.FirstOrDefaultAsync(c => c.PetId == id);
            var response = new Response();

            if (pet == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Nothing deleted, pet id " + id + " not found";
                return NotFound(response);
            }

            _context.Pets.Remove(pet);


            await _context.SaveChangesAsync();
            response.statusCode = 200;
            response.statusDescription = "Succesfully deleted pet with id " + id;

            return Ok(response);
        }

        private bool PetExists(int id)
        {
            return _context.Pets.Any(e => e.PetId == id);
        }
    }
}