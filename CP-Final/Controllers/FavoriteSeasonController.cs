using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CP_Final.Models;


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

        // Retrieve all FavoriteSeason entries
        [HttpGet]
        public ActionResult<List<FavoriteSeason>> GetAll()
        {
            return _context.FavoriteSeasons.ToList();
        }

        // Retrieve a single FavoriteSeason by ID
        [HttpGet("{id}")]
        public ActionResult<FavoriteSeason> Get(int id)
        {
            var favoriteSeason = _context.FavoriteSeasons.FirstOrDefault(fs => fs.Id == id);
            if (favoriteSeason == null)
            {
                return NotFound();
            }
            return favoriteSeason;
        }

        // Create a new FavoriteSeason
        [HttpPost]
        public ActionResult<FavoriteSeason> Post(FavoriteSeason favoriteSeason)
        {
            _context.FavoriteSeasons.Add(favoriteSeason);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = favoriteSeason.Id }, favoriteSeason);
        }

        // Update an existing FavoriteSeason
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

        // Delete a FavoriteSeason
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
