using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CP_Final.Models;


namespace CP_Final.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HobbyController : ControllerBase
    {
        private readonly DBContext _context;

        public HobbyController(DBContext context)
        {
            _context = context;
        }

        // Retrieve all Hobby entries
        [HttpGet]
        public ActionResult<List<Hobby>> GetAll()
        {
            return _context.Hobbies.ToList();
        }

        // Retrieve a single Hobby by ID
        [HttpGet("{id}")]
        public ActionResult<Hobby> Get(int id)
        {
            var hobby = _context.Hobbies.FirstOrDefault(h => h.Id == id);
            if (hobby == null)
            {
                return NotFound();
            }
            return hobby;
        }

        // Create a new Hobby
        [HttpPost]
        public ActionResult<Hobby> Post(Hobby hobby)
        {
            _context.Hobbies.Add(hobby);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = hobby.Id }, hobby);
        }

        // Update an existing Hobby
        [HttpPut("{id}")]
        public IActionResult Put(int id, Hobby hobby)
        {
            if (id != hobby.Id)
            {
                return BadRequest();
            }
            _context.Entry(hobby).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // Delete a Hobby
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var hobby = _context.Hobbies.Find(id);
            if (hobby == null)
            {
                return NotFound();
            }
            _context.Hobbies.Remove(hobby);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
