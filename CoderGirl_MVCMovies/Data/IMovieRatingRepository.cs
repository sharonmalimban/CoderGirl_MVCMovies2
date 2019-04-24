using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public interface IMovieRatingRepository
    {        
        /// <summary>
        /// Given a movieName and rating, saves the rating and returns a unique id > 0.
        /// If the movie name and/or rating are null or empty, nothing should be saved and it should return 0
        /// </summary>
        /// <param name="movieName"></param>
        /// <param name="rating"></param>
        /// <returns></returns>
        int SaveRating(string movieName, string rating);

        /// <summary>
        /// Given an id, will return the associated rating 
        /// If the id does not exist, returns null
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        string GetRatingById(int id);

        /// <summary>
        /// Given an id, will return the associated movie name.
        /// If the id does not exist, return null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetMovieNameById(int id);

        /// <summary>
        /// Given a movie name, returns a list of all ratings associated with the movie name.
        /// If there are no ratings for the movie, returns an empty list.
        /// </summary>
        /// <param name="movieName"></param>
        /// <returns></returns>
        List<string> GetRatingsByMovieName(string movieName);

        /// <summary>
        /// Given a rating, returns a list of all movie names with the given rating.
        /// If there are no movies with the given rating, returns an empty list.
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        List<string> GetMovieNamesByRating(string rating);

        /// <summary>
        /// Returns a list of all the ids of saved movie ratings
        /// </summary>
        /// <returns></returns>
        List<int> GetIds();
    }
}
