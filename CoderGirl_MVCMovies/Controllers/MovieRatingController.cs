﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {
        private IMovieRatingRepository repository = RepositoryFactory.GetMovieRatingRepository();
        public static List<Movie> movies = new List<Movie>();
        //public static Dictionary<Movie, double> movieAverages = new Dictionary<Movie, double>();

        private string htmlForm = @"
            <form method='post'>
                <input name='movieName' />
                <select name='rating'>
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>                    
                </select>
                <button type='submit'>Rate it</button>
            </form>";

        private void PopulateMovieList()
        {
            foreach (int id in repository.GetIds())
            {
                Movie mov = new Movie();
                mov.Id = movies.Count + 1;
                mov.Name = repository.GetMovieNameById(id);
                mov.Rating = repository.GetRatingById(id);
                movies.Add(mov);
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            PopulateMovieList();
            Dictionary<Movie, double> movieAverages = new Dictionary<Movie, double>();
            List<string> uniqueMovieNames = new List<string>();
            foreach (Movie movie in movies)
            {
                if(uniqueMovieNames.Contains(movie.Name))
                {
                    continue;
                }
                uniqueMovieNames.Add(movie.Name);
                movieAverages.Add(movie, repository.GetAverageRatingByMovieName(movie.Name));
            }
            ViewBag.Movies = movieAverages;
            
            return View("Index");
        }
                
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Movies = movies;
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(string movieName, string rating)
        {
            int id = repository.SaveRating(movieName, int.Parse(rating));

            return RedirectToAction(actionName: nameof(Details), routeValues: new { movieName, rating });
        }

        [HttpGet]
        public IActionResult Details(string movieName, string rating)
        {
            ViewBag.movieName = movieName;
            ViewBag.movieRating = rating;
            return View("Details");
        }
    }
}