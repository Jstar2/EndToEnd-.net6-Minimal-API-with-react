using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ApDbContext _dbContext;

        public PersonController(ApDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet] // this gets all people from db
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            var people = await _dbContext.People.ToListAsync();
            return Ok(people);
        }

        [HttpGet("{id}")] // get one by specific id
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _dbContext.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost] //this create or add new person to db
        public async Task<ActionResult<Person>> CreatePerson(Person person)
        {
            if (ModelState.IsValid)
            {
                _dbContext.People.Add(person);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, Person updatedPerson)
        {
            if (id != updatedPerson.Id)
            {
                return BadRequest();
            }

            var person = await _dbContext.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            person.FirstName = updatedPerson.FirstName;
            person.LastName = updatedPerson.LastName;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _dbContext.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _dbContext.People.Remove(person);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _dbContext.People.Any(p => p.Id == id);
        }
    }
}
