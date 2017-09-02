using ArcTouch.Cinephile.Views;
using ArcTouch.Cinephile.Views.Objects;

namespace ArcTouch.Cinephile.Presenters.Interfaces
{
    public interface IDetailsPresenter : IPresenter<DetailsView>
    {
        void ShowDetails(MovieItem movie);
    }
}
