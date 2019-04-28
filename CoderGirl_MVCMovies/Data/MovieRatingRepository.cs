using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRatingRepository : IMovieRatingRepository
    {
        public decimal GetAverageRatingByMovieName(string movieName)
        {
            throw new NotImplementedException();
        }

        public List<int> GetIds()
        {
            throw new NotImplementedException();
        }

        public string GetMovieNameById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetRatingById(int id)
        {
            throw new NotImplementedException();
        }

        public int SaveRating(string movieName, int rating)
        {
            Movie movie = new Movie();
            movie.Name = movieName; 
        }

        public static List<Movie> Movies = new List<Movie>();
            
    }
}
