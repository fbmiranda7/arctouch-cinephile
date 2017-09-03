using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcTouch.Cinephile.Services.TMDb
{
    /// <summary>
    /// Wraps the result json for the genre query
    /// </summary>
    public class GenresResult
    {
        [JsonProperty("genres")]
        public TMDb.Genre[] Genres { get; set; }
    }
}
