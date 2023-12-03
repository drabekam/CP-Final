using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CP_Final.Models;
using Microsoft.EntityFrameworkCore;


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

  
        [HttpGet("{id:int?}")]
        public ActionResult<List<Hobby>> Get(int? id)
        {
            if (!id.HasValue || id == 0)
            {
    
                return _context.Hobbies.Take(5).ToList();
            }
            else
            {
          
                var hobby = _context.Hobbies.FirstOrDefault(h => h.Id == id);

           
                if (hobby == null)
                {
                    return NotFound();
                }

            
                return new List<Hobby> { hobby };
            }
        }

    
        [HttpPost]
        public ActionResult<Hobby> Post(Hobby hobby)
        {
            _context.Hobbies.Add(hobby);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = hobby.Id }, hobby);
        }

    
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
