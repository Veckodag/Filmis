using FilmisApi.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FilmisTests
{
    public class MovieTests
    {
        private readonly MovieContext _context;

        public MovieTests()
        {
            var myDBContext = new DbContextOptionsBuilder<MovieContext>();
            myDBContext.UseInMemoryDatabase("Filmis");
            _context = new MovieContext(myDBContext.Options);
        }

        [Fact]
        public void Get_Correct_Movie()
        {
            var originalMovie = new Movie
            {
                Id = 1,
                Name = "Space Jam",
                Year = 1996
            };

            _context.Movies.Add(originalMovie);
            _context.SaveChanges();

            var databaseMovie = _context.Movies.Find(1);

            Assert.Equal(originalMovie, databaseMovie);
        }
    }
}
