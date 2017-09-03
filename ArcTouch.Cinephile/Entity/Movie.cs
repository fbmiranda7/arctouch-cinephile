using System;

namespace ArcTouch.Cinephile.Entity
{
    /// <summary>
    /// Base entity for Movie entity and it's annotation for Json deserialization
    /// </summary>
    public abstract class Movie
    {
        public abstract string Title { get; set; }

        public abstract string PosterPath { get; set; }

        public abstract int[] GenreIds { get; set; }

        public abstract string BackdropPath { get; set; }

        public abstract string OverView { get; set; }

        public abstract DateTime ReleaseDate { get; set; }
    }
}
