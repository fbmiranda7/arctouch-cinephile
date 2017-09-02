using ArcTouch.Cinephile.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcTouch.Cinephile.Services.TMDb
{
    /// <summary>
    /// Wraps the result json for the upcoming movies query
    /// </summary>
    public class Result
    {
        [JsonProperty("results")]
        public Movie[] Results { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        // [JsonProperty("dates")]
        // public object dates { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

    }
}
