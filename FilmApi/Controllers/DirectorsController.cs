namespace FilmApi.Controllers
{
    using FilmApi.Domain;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public DirectorsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Directors
        [HttpGet]
        public IEnumerable<Director> GetDirector()
        {
            return _context.Director;
        }

        // GET: api/Directors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDirector([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var director = await _context.Director.FindAsync(id);

            if (director == null)
            {
                return NotFound();
            }

            return Ok(director);
        }

        // PUT: api/Directors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirector([FromRoute] int id, [FromBody] Director director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != director.DirectorId)
            {
                return BadRequest();
            }

            _context.Entry(director).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(id))
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

        // POST: api/Directors
        [HttpPost]
        public async Task<IActionResult> PostDirector([FromBody] Director director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Director.Add(director);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirector", new { id = director.DirectorId }, director);
        }

        // DELETE: api/Directors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirector([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var director = await _context.Director.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }

            _context.Director.Remove(director);
            await _context.SaveChangesAsync();

            return Ok(director);
        }

        private bool DirectorExists(int id)
        {
            return _context.Director.Any(e => e.DirectorId == id);
        }
    }
}