
//Use Statements the models one allows me to call the dbcontext items as they are using that namespace

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CP_Final.Models;


namespace CP_Final.Controllers
{
    // Attribute indicating this class is an API controller 
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

        // HTTP GET method to retrieve all TeamMember entries
        // Route: /TeamMember
        [HttpGet]
        public ActionResult<List<TeamMember>> GetAll()
        {
            // Fetches all team members from the database and returns them
            return _context.TeamMembers.ToList();
        }

        // HTTP GET method to retrieve a single TeamMember by ID
        // Route: /TeamMember/{id}
        [HttpGet("{id}")]
        public ActionResult<TeamMember> Get(int id)
        {
            // Finds the team member with the specified ID
            var teamMember = _context.TeamMembers.FirstOrDefault(tm => tm.MemberID == id);

            // If not found returns a 404 
            if (teamMember == null)
            {
                return NotFound();
            }

            // Returns the found team member
            return teamMember;
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
            // Returns a 201 if it works
            return CreatedAtAction(nameof(Get), new { id = teamMember.MemberID }, teamMember);
        }

        // HTTP PUT method to update an existing TeamMember
        // Route: /TeamMember/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, TeamMember teamMember)
        {
            // Checks if the ID in the URL matches the team members ID
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

            // Updates the team members
            existingTeamMember.MemberName = teamMember.MemberName;
            existingTeamMember.BirthDate = teamMember.BirthDate;
            existingTeamMember.Program = teamMember.Program;
            existingTeamMember.MemberYear = teamMember.MemberYear;

            // Marks the team member as updated
            _context.TeamMembers.Update(existingTeamMember);
            // Saves the changes to the database
            _context.SaveChanges();

            // Returns a 204 
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

            // Returns a 204 
            return NoContent();
        }
    }
}
