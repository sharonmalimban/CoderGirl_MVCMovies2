using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoderGirl_MVCMovies.Data;
using Xunit;

namespace Test
{
    public class TestIMovieRatingRepository
    {
        private IMovieRatingRepository repository;

        public TestIMovieRatingRepository()
        {
            repository = RepositoryFactory.GetMovieRatingRepository();
        }

        [Fact]
        public void TestSave_ReturnsDistinctIds_GreaterThanZero()
        {
            List<int> ids = new List<int>();
            ids.Add(repository.SaveRating("movie1", "rating1"));
            ids.Add(repository.SaveRating("movie2", "rating2"));
            ids.Add(repository.SaveRating("movie3", "rating3"));

            var distinctResults = ids.Distinct();
            Assert.Equal(3, distinctResults.Count());
            Assert.True(distinctResults.Min() > 0);
        }

        [Theory]
        public void TestGetMovieNameById_ReturnsMovieName_WhenGivenId(string movieName)
        {


            var result = repository.GetMovieNameById(id);

            Assert.Equal(movieName, result);
        }
    }
}
