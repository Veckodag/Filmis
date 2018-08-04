using FilmisApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FilmisTests
{    
    public class ActorTests
    {
        private readonly MovieContext _context;

        public ActorTests()
        {
            var myDBContext = new DbContextOptionsBuilder<MovieContext>();
            myDBContext.UseInMemoryDatabase("Filmis");
            _context = new MovieContext(myDBContext.Options);
        }

        [Fact]
        public void Get_Correct_Actor_By_ID_From_Database()
        {
            //Arrange
            var originalActor = new Actor { Id = 27, Name = "Jackie Chan" };
            _context.Actors.Add(originalActor);
            _context.SaveChanges();

            //Act
            Actor databaseActor = _context.Actors.Find(27);

            //Assert
            Assert.Equal(originalActor, databaseActor);
        }
    }
}
