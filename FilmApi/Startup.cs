namespace FilmApi
{
    using FilmApi.Domain;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<MainDbContext>(options =>
                            options.UseSqlServer(
                                Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<MainDbContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MainDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            LoadData(context).Wait();
        }

        private async Task LoadData(MainDbContext context)
        {
            try
            {
                List<Country> countries = new List<Country>
                {
                    new Country()
                    {
                        Name = "United States",
                    },
                    new Country()
                    {
                        Name = "Spain",
                    },
                    new Country()
                    {
                        Name = "United Kingdom",
                    },
                };

                await context.Country.AddRangeAsync(countries);

                List<Film> films = new List<Film>
                {
                    // Stanley Kubrick
                    new Film()
                    {
                        Title = "Espartaco ",
                        OriginalTitle = "Spartacus",
                        Imdb = 7.9M,
                        Year = new DateTime(1960, 10, 7),
                        Duration = 184
                    },
                    new Film()
                    {
                        Title = "¿Teléfono rojo? ",
                        OriginalTitle = "Dr. Strangelove or: How I Learned to Stop Worrying and Love the Bomb",
                        Imdb = 8.4M,
                        Year = new DateTime(1989, 1, 29),
                        Duration = 95
                    },
                    new Film()
                    {
                        Title = "2001: Una odisea del espacio",
                        OriginalTitle = "2001: A Space Odyssey",
                        Imdb = 8.3M,
                        Year = new DateTime(1968, 9, 3),
                        Duration = 149
                    },
                    new Film()
                    {
                        Title = "La naranja mecánica",
                        OriginalTitle = "A Clockwork Orange",
                        Imdb = 8.3M,
                        Year = new DateTime(1972, 2, 2),
                        Duration = 136
                    },
                    new Film()
                    {
                        Title = "El resplandor",
                        OriginalTitle = "The Shining",
                        Imdb = 8.4M,
                        Year = new DateTime(1980, 6, 13),
                        Duration = 146
                    },
                    new Film()
                    {
                        Title = "La chaqueta metálica",
                        OriginalTitle = "Full Metal Jacket",
                        Imdb = 8.3M,
                        Year = new DateTime(1987, 7, 10),
                        Duration = 106
                    }

                    // Clint Eastwood

                    // Martin Scorsese

                    // Steven Spielberg
                };

                await context.Film.AddRangeAsync(films);

                Director Director = new Director()
                {
                    Name = "Stanley",
                    Surname = "Kubrick"
                };

                await context.Director.AddAsync(Director);

                await context.SaveChangesAsync();

                foreach (var film in films)
                {
                    var movieDirector = new MovieDirector()
                    {
                        FilmId = film.FilmId,
                        DirectorId = Director.DirectorId
                    };

                    await context.MovieDirector.AddAsync(movieDirector);
                }

                foreach (var film in films)
                {
                    var movieCountry = new MovieCountry()
                    {
                        FilmId = film.FilmId,
                        CountryId = 1
                    };

                    await context.MovieCountry.AddAsync(movieCountry);
                }

                // Pedro Almodóvar

                // Fernando Trueba

                /*
                foreach (var film in films)
                {
                    var movieCountry = new MovieCountry()
                    {
                        FilmId = film.FilmId,
                        CountryId = 2
                    };

                    await context.MovieCountry.AddAsync(movieCountry);
                }*/

                // Alfred Hitchcock

                // David Lean

                /*
                foreach (var film in films)
                {
                    var movieCountry = new MovieCountry()
                    {
                        FilmId = film.FilmId,
                        CountryId = 3
                    };

                    await context.MovieCountry.AddAsync(movieCountry);
                }*/

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //Log, handle or absorbe I don't care ^_^
            }
        }
    }
}