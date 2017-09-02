using ArcTouch.Cinephile.Base;
using ArcTouch.Cinephile.IoC;
using ArcTouch.Cinephile.Presenters.Interfaces;
using ArcTouch.Cinephile.Services;
using ArcTouch.Cinephile.Views;
using ArcTouch.Cinephile.Views.Objects;
using System;
using System.Linq;
using Xamarin.Forms;

namespace ArcTouch.Cinephile.Presenters
{
    public class DetailsPresenter : BasePresenter<DetailsView>, IDetailsPresenter
    {
        public DetailsPresenter(DetailsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Fill the view fields with its respective values
        /// </summary>
        /// <param name="movieItem"></param>
        public void ShowDetails(MovieItem movieItem)
        {
            IMovieProvider provider = Resolver.Get<IMovieProvider>();

            View.ShowDetails(
                ImageSource.FromUri(new Uri(movieItem.Movie.PosterPath)),
                movieItem.Movie.OverView,
                movieItem.Movie.Title,
                string.Join(", ", provider.GetGenres(movieItem.Movie.GenreIds).Select(c => c.Name)),
                movieItem.ReleaseDate
                );
        }
    }
}
