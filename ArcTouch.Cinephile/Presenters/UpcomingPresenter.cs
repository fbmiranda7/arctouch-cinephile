using ArcTouch.Cinephile.Base;
using ArcTouch.Cinephile.Entity;
using ArcTouch.Cinephile.Native;
using ArcTouch.Cinephile.Presenters.Interfaces;
using ArcTouch.Cinephile.Services;
using ArcTouch.Cinephile.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using ArcTouch.Cinephile.Views.Objects;

namespace ArcTouch.Cinephile.Presenters
{
    public class UpcomingPresenter : BasePresenter<UpcomingView>, IUpcomingPresenter
    {
        private IMovieProvider provider;
        private int page = 1;

        public UpcomingPresenter(UpcomingView view, IMovieProvider provider)
            : base(view)
        {
            this.provider = provider;
        }

        /// <summary>
        /// Fetches movies from the provider and appends the retrived items to the end of the list
        /// </summary>
        /// <returns></returns>
        public async Task FetchAndAppend()
        {
            View.IsBusy = true;

            try
            {
                DependencyService.Get<INativeUi>().DisplayTooltip("Loading...");

                IEnumerable<Movie> upcomingMovies = await provider.FetchUpcoming(page++);

                View.AppendResults(upcomingMovies);
            }
            catch(Exception ex)
            {
                View.DisplayAlert("Error", "An unexpected error has occured, please try again.", string.Empty);
            }
            finally
            {
                View.IsBusy = false;
            }
        }

        /// <summary>
        /// Called by the view when a item is selected
        /// </summary>
        /// <param name="movieItem"></param>
        public void OnItemSelected(MovieItem movieItem)
        {
            var detailsPresenter = Present<IDetailsPresenter, DetailsView>();
            detailsPresenter.ShowDetails(movieItem);
        }
    }
}
