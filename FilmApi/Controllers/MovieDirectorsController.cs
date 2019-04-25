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
    public class MovieDirectorsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public MovieDirectorsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/MovieDirectors
        [HttpGet]
        public IEnumerable<MovieDirector> GetMovieDirector()
        {
            return _context.MovieDirector;
        }

        // GET: api/MovieDirectors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieDirector([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieDirector = await _context.MovieDirector.FindAsync(id);

            if (movieDirector == null)
            {
                return NotFound();
            }

            return Ok(movieDirector);
        }

        // PUT: api/MovieDirectors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieDirector([FromRoute] int id, [FromBody] MovieDirector movieDirector)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movieDirector.MovieDirectorId)
            {
                return BadRequest();
            }

            _context.Entry(movieDirector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieDirectorExists(id))
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

        // POST: api/MovieDirectors
        [HttpPost]
        public async Task<IActionResult> PostMovieDirector([FromBody] MovieDirector movieDirector)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MovieDirector.Add(movieDirector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieDirector", new { id = movieDirector.MovieDirectorId }, movieDirector);
        }

        // DELETE: api/MovieDirectors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieDirector([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieDirector = await _context.MovieDirector.FindAsync(id);
            if (movieDirector == null)
            {
                return NotFound();
            }

            _context.MovieDirector.Remove(movieDirector);
            await _context.SaveChangesAsync();

            return Ok(movieDirector);
        }

        private bool MovieDirectorExists(int id)
        {
            return _context.MovieDirector.Any(e => e.MovieDirectorId == id);
        }
    }
}