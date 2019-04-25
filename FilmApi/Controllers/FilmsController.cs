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
    public class FilmsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public FilmsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Films
        [HttpGet]
        public IEnumerable<Film> GetFilm()
        {
            return _context.Film;
        }

        // GET: api/Films/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilm([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var film = await _context.Film.FindAsync(id);

            if (film == null)
            {
                return NotFound();
            }

            return Ok(film);
        }

        // PUT: api/Films/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilm([FromRoute] int id, [FromBody] Film film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != film.FilmId)
            {
                return BadRequest();
            }

            _context.Entry(film).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
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

        // POST: api/Films
        [HttpPost]
        public async Task<IActionResult> PostFilm([FromBody] Film film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Film.Add(film);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilm", new { id = film.FilmId }, film);
        }

        // DELETE: api/Films/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var film = await _context.Film.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }

            _context.Film.Remove(film);
            await _context.SaveChangesAsync();

            return Ok(film);
        }

        private bool FilmExists(int id)
        {
            return _context.Film.Any(e => e.FilmId == id);
        }
    }
}