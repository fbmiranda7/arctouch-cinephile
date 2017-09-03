using ArcTouch.Cinephile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ArcTouch.Cinephile.Views.Objects;

namespace ArcTouch.Cinephile.Presenters.Interfaces
{
    public interface IUpcomingPresenter : IPresenter<UpcomingView>
    {
        Task FetchAndAppend();
        void OnItemSelected(MovieItem movieItem);
        void OnSearchTapped();
        void OnSearchBarUnfocused();
        void OnSearch(string oldTextValue, string newTextValue);
    }
}
