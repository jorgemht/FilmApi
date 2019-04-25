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
    public class MovieCountriesController : ControllerBase
    {
        private readonly MainDbContext _context;

        public MovieCountriesController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/MovieCountries
        [HttpGet]
        public IEnumerable<MovieCountry> GetMovieCountry()
        {
            return _context.MovieCountry;
        }

        // GET: api/MovieCountries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieCountry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieCountry = await _context.MovieCountry.FindAsync(id);

            if (movieCountry == null)
            {
                return NotFound();
            }

            return Ok(movieCountry);
        }

        // PUT: api/MovieCountries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieCountry([FromRoute] int id, [FromBody] MovieCountry movieCountry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movieCountry.MovieCountryId)
            {
                return BadRequest();
            }

            _context.Entry(movieCountry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieCountryExists(id))
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

        // POST: api/MovieCountries
        [HttpPost]
        public async Task<IActionResult> PostMovieCountry([FromBody] MovieCountry movieCountry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MovieCountry.Add(movieCountry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieCountry", new { id = movieCountry.MovieCountryId }, movieCountry);
        }

        // DELETE: api/MovieCountries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieCountry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieCountry = await _context.MovieCountry.FindAsync(id);
            if (movieCountry == null)
            {
                return NotFound();
            }

            _context.MovieCountry.Remove(movieCountry);
            await _context.SaveChangesAsync();

            return Ok(movieCountry);
        }

        private bool MovieCountryExists(int id)
        {
            return _context.MovieCountry.Any(e => e.MovieCountryId == id);
        }
    }
}