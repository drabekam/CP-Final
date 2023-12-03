using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CP_Final.Models;
using Microsoft.EntityFrameworkCore;


namespace CP_Final.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavoriteFoodController : ControllerBase
    {
     
        private readonly DBContext _context;

        public FavoriteFoodController(DBContext context)
        {
            _context = context;
        }

       
        [HttpGet("{id:int?}")]
        public ActionResult<List<FavoriteFood>> Get(int? id)
        {
            if (!id.HasValue || id == 0)
            {
                
                return _context.FavoriteFoods.Take(5).ToList();
            }
            else
            {
               
                var favoriteFood = _context.FavoriteFoods.FirstOrDefault(ff => ff.Id == id);

                if (favoriteFood == null)
                {
                    return NotFound();
                }

              
                return new List<FavoriteFood> { favoriteFood };
            }
        }

     
        [HttpPost]
        public ActionResult<FavoriteFood> Post(FavoriteFood favoriteFood)
        {
            _context.FavoriteFoods.Add(favoriteFood);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = favoriteFood.Id }, favoriteFood);
        }

      
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
