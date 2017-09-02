using ArcTouch.Cinephile.IoC;
using ArcTouch.Cinephile.Presenters.Interfaces;
using ArcTouch.Cinephile.Views;
using Xamarin.Forms;

namespace ArcTouch.Cinephile.Base
{
    public abstract class BasePresenter<TV> : IPresenter<TV>
        where TV : BaseView
    {
        public TV View { get; set; }

        public BasePresenter(TV view)
        {
            this.View = view;
        }

        /// <summary>
        /// Presents and returns a Presenter of a desired View
        /// </summary>
        /// <typeparam name="TP"></typeparam>
        /// <typeparam name="TPV"></typeparam>
        /// <returns></returns>
        public TP Present<TP, TPV>()
            where TP : IPresenter<TPV>
            where TPV : BaseView
        {
            TP presenter = Resolver.Get<TP>();

            // navigates forward
            View.Navigation.PushAsync((Page)presenter.View);

            return presenter;
        }
    }
}
