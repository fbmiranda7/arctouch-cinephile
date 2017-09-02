using ArcTouch.Cinephile.Base;

namespace ArcTouch.Cinephile.Presenters.Interfaces
{
    public interface IPresenter<TV>
        where TV : BaseView
    {
        TV View { get; set; }

        TP Present<TP, TPV>()
            where TP : IPresenter<TPV>
            where TPV : BaseView;
    }
}
