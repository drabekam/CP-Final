using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CP_Final.Models;


namespace CP_Final.Controllers
{

    [ApiController]
    [Route("[controller]")] 
    public class FavoriteFoodController : ControllerBase
    {
        private readonly YourDbContext _context; 

    
        public FavoriteFoodController(YourDbContext context)
        {
            _context = context;
        }

        // GET method to retrieve all FavoriteFood items
        [HttpGet]
        public ActionResult<List<FavoriteFood>> GetAll()
        {
            return _context.FavoriteFoods.ToList();
        }

        // GET method to retrieve a single FavoriteFood by ID
        [HttpGet("{id}")]
        public ActionResult<FavoriteFood> Get(int id)
        {
            var favoriteFood = _context.FavoriteFoods.FirstOrDefault(ff => ff.Id == id);
            if (favoriteFood == null)
            {
                return NotFound(); 
            }
            return favoriteFood;
        }

        // POST method to create a new FavoriteFood item
        [HttpPost]
        public ActionResult<FavoriteFood> Post(FavoriteFood favoriteFood)
        {
            _context.FavoriteFoods.Add(favoriteFood);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = favoriteFood.Id }, favoriteFood);
        }

        // PUT method to update an existing FavoriteFood item
        [HttpPut("{id}")]
        public IActionResult Put(int id, FavoriteFood favoriteFood)
        {
            if (id != favoriteFood.Id)
            {
                return BadRequest(); 
            }
            _context.Entry(favoriteFood).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE method to delete a FavoriteFood item
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var favoriteFood = _context.FavoriteFoods.Find(id);
            if (favoriteFood == null)
            {
                return NotFound(); 
            }
            _context.FavoriteFoods.Remove(favoriteFood);
            _context.SaveChanges();
            return NoContent(); 
        }
    }
}
