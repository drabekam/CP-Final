using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CP_Final.Models;
using Microsoft.EntityFrameworkCore; // Ensure this is added if EntityState is used

namespace CP_Final.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavoriteSeasonController : ControllerBase
    {
        private readonly DBContext _context;

        public FavoriteSeasonController(DBContext context)
        {
            _context = context;
        }

        
        [HttpGet("{id:int?}")]
        public ActionResult<List<FavoriteSeason>> Get(int? id)
        {
            if (!id.HasValue || id == 0)
            {
              
                return _context.FavoriteSeasons.Take(5).ToList();
            }
            else
            {
               
                var favoriteSeason = _context.FavoriteSeasons.FirstOrDefault(fs => fs.Id == id);

             
                if (favoriteSeason == null)
                {
                    return NotFound();
                }

            
                return new List<FavoriteSeason> { favoriteSeason };
            }
        }

      
        [HttpPost]
        public ActionResult<FavoriteSeason> Post(FavoriteSeason favoriteSeason)
        {
            _context.FavoriteSeasons.Add(favoriteSeason);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = favoriteSeason.Id }, favoriteSeason);
        }

     
        [HttpPut("{id}")]
        public IActionResult Put(int id, FavoriteSeason favoriteSeason)
        {
            if (id != favoriteSeason.Id)
            {
                return BadRequest();
            }
            _context.Entry(favoriteSeason).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

     
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var favoriteSeason = _context.FavoriteSeasons.Find(id);
            if (favoriteSeason == null)
            {
                return NotFound();
            }
            _context.FavoriteSeasons.Remove(favoriteSeason);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
