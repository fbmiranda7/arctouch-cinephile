using ArcTouch.Cinephile.Entity;
using System;
using Xamarin.Forms;

namespace ArcTouch.Cinephile.Views.Objects
{
    /// <summary>
    /// View object for ui presentation/binding
    /// </summary>
    public class MovieItem
    {
        /// <summary>
        /// Movie to be displayed
        /// </summary>
        public Movie Movie { get; }

        /// <summary>
        /// Date device/language specific format
        /// </summary>
        public string ReleaseDate
        {
            get
            {
                return Movie.ReleaseDate.Date.GetDateTimeFormats()[0];
            }
        }

        public MovieItem(Movie movie)
        {
            Movie = movie;
        }
    }
}
