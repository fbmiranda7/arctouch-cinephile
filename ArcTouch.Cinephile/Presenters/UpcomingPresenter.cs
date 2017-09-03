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
using System.Linq;

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
                Tooptip("Loading...");

                IEnumerable<Movie> upcomingMovies = await provider.FetchUpcoming(page++);

                View.AppendResults(upcomingMovies, false);
            }
            catch
            {
                Tooptip("An unexpected error has occured, please try again.");
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

        string lastSearch;

        /// <summary>
        /// Waits for some time after the last entered text, if equals last one does the search
        /// </summary>
        /// <param name="oldTextValue"></param>
        /// <param name="newTextValue"></param>
        public void OnSearch(string oldTextValue, string newTextValue)
        {
            if (string.IsNullOrEmpty(newTextValue))
            {
                page = 1;
                View.ClearResults();
                FetchAndAppend();
            }
            else
            {
                View.IsBusy = true;

                lastSearch = newTextValue;

                Task.Run(async () =>
                {
                    string searchText = lastSearch;

                    await Task.Delay(1500);

                    if (lastSearch == searchText)
                        await DoSearchAsync();
                });
            }
        }

        /// <summary>
        /// Searches and informs the user of the results
        /// </summary>
        /// <returns></returns>
        private async Task DoSearchAsync()
        {
            try
            {
                Tooptip("Searching...");

                IEnumerable<Movie> search = await provider.Search(lastSearch);

                View.ClearResults();

                UiThread(() =>
                {
                    if (search.Count() == 0)
                        Tooptip("No movie matched your query, please try different terms.");
                    else
                        View.AppendResults(search, true);
                });
            }
            catch
            {
                 Tooptip("An unexpected error has occured, please try again.");
            }
            finally
            {
                View.IsBusy = false;
            }
        }

        private void Tooptip(string text)
        {
            UiThread(() => DependencyService.Get<INativeUi>().DisplayTooltip(text));
        }

        private void UiThread(Action action)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(action);
        }

        public void OnSearchBarUnfocused()
        {
            View.DisplaySearchTextBox(false);
        }

        /// <summary>
        /// Search image has been tapped
        /// </summary>
        public void OnSearchTapped()
        {
            View.DisplaySearchTextBox(true);
        }
    }
}
