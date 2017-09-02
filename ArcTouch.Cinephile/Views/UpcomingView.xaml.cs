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

namespace ArcTouch.Cinephile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpcomingView : BaseView
    {
        private ObservableCollection<MovieItem> movieList = new ObservableCollection<MovieItem>();

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
            var items = list.ItemsSource as IList;

            // on the last item, request for more
            if (e.Item == items[items.Count - 1])
                Presenter.FetchAndAppend();
        }

        internal void AppendResults(IEnumerable<Movie> upcomingMovies)
        {
            // append items to the end of the observable collection, not refreshing it entirely
            foreach (Movie movie in upcomingMovies)
                movieList.Add(new MovieItem(movie));
        }

    }
}