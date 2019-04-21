using CoderGirl_MVCMovies;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using System.IO;

namespace Test
{
    public class TestMovieRatingViews : IDisposable
    {
        private ChromeDriver driver;


        public TestMovieRatingViews()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [Fact]
        public void TestCreate()
        {
            driver.Navigate
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
