using ArcTouch.Cinephile.Views;
using System.Threading.Tasks;

namespace ArcTouch.Cinephile.Presenters.Interfaces
{
    public interface ISplashPresenter : IPresenter<SplashView>
    {
        Task Delay();
        Task FadeIn();
    }
}
