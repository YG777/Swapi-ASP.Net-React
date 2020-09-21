using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReactApp.Models
{
    public class Movie
    {
        [JsonProperty("episode_id")]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public string Producer { get; set; }
    }
}
