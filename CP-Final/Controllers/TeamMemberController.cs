using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CP_Final.Models;
using Microsoft.EntityFrameworkCore;

namespace CP_Final.Controllers
{
    // indicates that this class is an API controller 
    [ApiController]
    [Route("[controller]")]
    public class TeamMemberController : ControllerBase
    {
        // Private field for the database context
        private readonly DBContext _context;

        // Constructor that accepts DBContext as a dependency and initializes the _context field
        public TeamMemberController(DBContext context)
        {
            _context = context;
        }

        // Combined HTTP GET method to retrieve a single TeamMember by ID or the first five TeamMember entries
        // If id is null or zero
        // Route: /TeamMember/{id}
        [HttpGet("{id:int?}")]
        public ActionResult<List<TeamMember>> Get(int? id)
        {
            if (!id.HasValue || id == 0)
            {
                // gets first five team members from the database and returns them
                return _context.TeamMembers.Take(5).ToList();
            }
            else
            {
                // Finds the team member with the specified ID
                var teamMember = _context.TeamMembers.FirstOrDefault(tm => tm.MemberID == id);

                // If not found returns a 404 
                if (teamMember == null)
                {
                    return NotFound();
                }

                // Returns the found team member
                return new List<TeamMember> { teamMember };
            }
        }

        // HTTP POST method to create a new TeamMember
        // Route: /TeamMember
        [HttpPost]
        public ActionResult<TeamMember> Post(TeamMember teamMember)
        {
            // Adds the new team member to the database context
            _context.TeamMembers.Add(teamMember);
            // Saves the changes to the database
            _context.SaveChanges();
            // Returns a 201 Created response with the newly created team member
            return CreatedAtAction(nameof(Get), new { id = teamMember.MemberID }, teamMember);
        }

        // HTTP PUT method to update an existing TeamMember
        // Route: /TeamMember/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, TeamMember teamMember)
        {
            // Checks if the ID in the URL matches the team member's ID
            if (id != teamMember.MemberID)
            {
                return BadRequest();
            }

            // Finds the existing team member 
            var existingTeamMember = _context.TeamMembers.FirstOrDefault(tm => tm.MemberID == id);
            // If not found, returns a 404 Not Found response
            if (existingTeamMember == null)
            {
                return NotFound();
            }

            // Updates the team member's properties
            existingTeamMember.MemberName = teamMember.MemberName;
            existingTeamMember.BirthDate = teamMember.BirthDate;
            existingTeamMember.Program = teamMember.Program;
            existingTeamMember.MemberYear = teamMember.MemberYear;

            // Marks the team member as updated
            _context.TeamMembers.Update(existingTeamMember);
            // Saves the changes to the database
            _context.SaveChanges();

            // Returns a 204 No Content response
            return NoContent();
        }

        // HTTP DELETE method to delete a TeamMember
        // Route: /TeamMember/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // Finds the team member to delete
            var teamMember = _context.TeamMembers.FirstOrDefault(tm => tm.MemberID == id);
            // If not found, returns a 404 
            if (teamMember == null)
            {
                return NotFound();
            }

            // Removes the team member from the database
            _context.TeamMembers.Remove(teamMember);
            // Saves the changes to the database
            _context.SaveChanges();

            // Returns a 204 No Content response
            return NoContent();
        }
    }
}
