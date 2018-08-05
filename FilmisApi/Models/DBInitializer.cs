using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace FilmisApi.Models
{
    public static class DBInitializer
    {
        public static void Initializer(IServiceProvider serviceProvider)
        {
            using (var context = new MovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>()))
            {
                if (context.Movies.Any() && context.Actors.Any())               
                    return; // Already seeded!

                context.Actors.AddRange(
                    new Actor { Name = "Michael Jordan" },
                    new Actor { Name = "Bill Murray" },
                    new Actor { Name = "Kyrie Irving" },
                    new Actor { Name = "Nate Robinson" },
                    new Actor { Name = "Shaquille O'Neal" }
                    );
                context.SaveChanges();

                // Inconventional way to select stuff :D
                context.Movies.AddRange(
                    new Movie { Name = "Space Jam", Year = 1996, Actors = context.Actors.Take(2).ToList() },
                    new Movie { Name = "Uncle Drew", Year = 2018, Actors = context.Actors.Skip(2).Take(3).ToList() },
                    new Movie { Name = "Groundhog Day", Year = 1993, Actors = context.Actors.Skip(1).Take(1).ToList() }
                    );

                context.SaveChanges();
            }
        }
    }
}
