namespace FilmApi
{
    using FilmApi.Domain;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class MainDbContext : IdentityDbContext<IdentityUser>
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Country> Country { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<MovieCountry> MovieCountry { get; set; }
        public DbSet<MovieDirector> MovieDirector { get; set; }
    }
}
