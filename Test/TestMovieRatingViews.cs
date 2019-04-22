using CoderGirl_MVCMovies;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using System.IO;
using OpenQA.Selenium.Support.UI;

namespace Test
{
    public class TestMovieRatingViews : IDisposable
    {
        private ChromeDriver driver;
        private const string BASE_URL = "http://localhost:59471/movierating";


        public TestMovieRatingViews()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [Theory]
        [InlineData("Star Wars", "5")]
        [InlineData("Princess Bride", "4")]
        public void TestCreate(string name, string rating)
        {
            driver.Url = BASE_URL + "/create";
            var source = driver.PageSource;
            var submit = driver.FindElementByTagName("button");
            Assert.Equal("submit", submit.GetAttribute("type"));
            var nameInput = driver.FindElementByName("movieName");
            var ratingInput = new SelectElement(driver.FindElementByName("rating"));

            nameInput.SendKeys(name);
            ratingInput.SelectByText(rating);
            submit.Click();

            Assert.Equal(Uri.EscapeUriString(BASE_URL + $"/details?movieName={name}&rating={rating}"), driver.Url, true);
        }

        public void Dispose()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
