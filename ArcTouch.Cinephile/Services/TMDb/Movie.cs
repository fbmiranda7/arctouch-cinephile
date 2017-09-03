using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcTouch.Cinephile.Services.TMDb
{
    /// <summary>
    /// Commented are some other useful properties
    /// </summary>
    public class Movie : ArcTouch.Cinephile.Entity.Movie
    {
        //[JsonProperty("vote_count")]
        //public int VoteCount { get; set; }

        //[JsonProperty("id")]
        //public int Id { get; set; }

        //[JsonProperty("video")]
        //public bool Video { get; set; }

        //[JsonProperty("vote_average")]
        //public double VoteAverage { get; set; }

        [JsonProperty("title")]
        public override string Title { get; set; }

        //[JsonProperty("popularity")]
        //public double Popularity { get; set; }

        [JsonProperty("poster_path")]
        public override string PosterPath { get; set; }

        //[JsonProperty("original_language")]
        //public string OriginalLanguage { get; set; }

        //[JsonProperty("original_title")]
        //public string OriginalTitle { get; set; }

        [JsonProperty("genre_ids")]
        public override int[] GenreIds { get; set; }

        [JsonProperty("backdrop_path")]
        public override string BackdropPath { get; set; }

        //[JsonProperty("adult")]
        //public bool Adult { get; set; }

        [JsonProperty("overview")]
        public override string OverView { get; set; }

        [JsonProperty("release_date")]
        public override DateTime ReleaseDate { get; set; }
    }
}
