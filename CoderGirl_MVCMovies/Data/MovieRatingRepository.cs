﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRatingRepository : IMovieRatingRepository
    {
        public double GetAverageRatingByMovieName(string movieName)
        {
            return Movies.Where(m => m.Name == movieName).Average(m => m.Rating);
        }

        public List<int> GetIds()
        {
            return Movies.Select(m => m.Id).ToList();
        }

        public string GetMovieNameById(int id)
        {
            return Movies[id - 1].Name;
            
        }

        public int GetRatingById(int id)
        {
            return Movies[id - 1].Rating;
            
        }

        public int SaveRating(string movieName, int rating)
        {
            

            // Given a movieName and rating, saves the rating and returns a unique id > 0.
            // If the movie name and/or rating are null or empty, nothing should be saved and it should return 0
            if (String.IsNullOrEmpty(movieName) || rating == 0)
            {
                return 0;
            }
            Movie movie = new Movie();
            movie.Name = movieName;
            movie.Rating = rating;
            movie.Id = Movies.Count + 1;
            Movies.Add(movie);
            return movie.Id;
        }

        public static List<Movie> Movies = new List<Movie>();
            
    }
}
