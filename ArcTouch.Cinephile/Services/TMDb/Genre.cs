using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcTouch.Cinephile.Services.TMDb
{
    /// <summary>
    /// Wraps the json for a Genre
    /// </summary>
    public class Genre : ArcTouch.Cinephile.Entity.Genre
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public override string Name { get; set; }
    }
}
