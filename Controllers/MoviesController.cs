using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReactApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly List<Movie> movies = new List<Movie>();
        //public MoviesController()
        //{
        //    movies.Add(new Movie { Id = 1, Title = "Title 1", Director = "Director 1", Producer = "Producer 1" });
        //    movies.Add(new Movie { Id = 2, Title = "Title 2", Director = "Director 2", Producer = "Producer 2" });
        //    movies.Add(new Movie { Id = 3, Title = "Title 3", Director = "Director 3", Producer = "Producer 3" });
        //}

        //[HttpGet]
        //public List<Movie> Get(string q)
        //{
        //    return movies;
        //}

        public readonly IHttpClientFactory _factory;
        public MoviesController(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string q)
        {
            var client = _factory.CreateClient();
            var uri = new Uri($"https://swapi.dev/api/films/?search={q}");
            var json = await client.GetStringAsync(uri);
            var jObj = JObject.Parse(json);
            var movies = JsonConvert.DeserializeObject<IList<Movie>>(jObj["results"].ToString());
            return Ok(movies);
        }
    }
}
