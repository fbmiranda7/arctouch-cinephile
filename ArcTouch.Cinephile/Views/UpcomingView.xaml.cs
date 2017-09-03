using ArcTouch.Cinephile.Base;
using ArcTouch.Cinephile.Entity;
using ArcTouch.Cinephile.IoC;
using ArcTouch.Cinephile.Presenters.Interfaces;
using ArcTouch.Cinephile.Views.Objects;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using System.Threading.Tasks;
using System.Net;

namespace ArcTouch.Cinephile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpcomingView : BaseView
    {
        private ObservableCollection<MovieItem> movieList = new ObservableCollection<MovieItem>();
        private bool isSearch;

        private IUpcomingPresenter Presenter
        {
            get
            {
                return Resolver.Get<IUpcomingPresenter>();
            }
        }

        public UpcomingView ()
		{
            InitializeComponent();

            Title = "Upcoming movies";

            list.ItemAppearing += List_ItemAppearing;
            list.ItemSelected += List_ItemSelected;

            list.ItemsSource = movieList;

            search.GestureRecognizers.Add(new TapGestureRecognizer(SearchTapped));
            searchBar.Unfocused += SearchBar_Unfocused;
            searchBar.TextChanged += SearchBar_TextChanged;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Presenter.OnSearch(e.OldTextValue, e.NewTextValue);
        }

        private void SearchBar_Unfocused(object sender, FocusEventArgs e)
        {
            Presenter.OnSearchBarUnfocused();
        }

        private void SearchTapped(View sender)
        {
            Presenter.OnSearchTapped();
        }

        private void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Presenter.OnItemSelected(e.SelectedItem as MovieItem);

                // removes the background selection
                list.SelectedItem = null;
            }
        }

        private void List_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (!isSearch)
            {
                var items = list.ItemsSource as IList;

                // on the last item, request for more
                if (items.Count > 0 && e.Item == items[items.Count - 1])
                    Presenter.FetchAndAppend();
            }
        }

        internal void AppendResults(IEnumerable<Movie> upcomingMovies, bool isSearch)
        {
            this.isSearch = isSearch;

            // append items to the end of the observable collection, not refreshing it entirely
            foreach (Movie movie in upcomingMovies)
                movieList.Add(new MovieItem(movie));

            if (isSearch && movieList.Count > 0)
                list.ScrollTo(movieList[0], ScrollToPosition.Start, false);
        }

        internal void DisplaySearchTextBox(bool display)
        {
            searchBar.IsVisible = bgSearchBar.IsVisible = display;
            search.IsVisible = !display;

            if (display)
                searchBar.Focus();
        }

        internal void ClearResults()
        {
            try
            {
                movieList.Clear();
            }
            catch (WebException)
            {
                // some requests get aborted when clearing the list, just ignore
            }
        }
    }
}