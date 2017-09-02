using ArcTouch.Cinephile.Base;
using ArcTouch.Cinephile.Presenters.Interfaces;
using ArcTouch.Cinephile.Views;
using System.Threading.Tasks;

namespace ArcTouch.Cinephile.Presenters
{
    public class SplashPresenter : BasePresenter<SplashView>, ISplashPresenter
    {
        public SplashPresenter(SplashView view)
            : base(view)
        {
        }

        /// <summary>
        /// Delays the display of the upcomming view
        /// </summary>
        /// <returns></returns>
        public async Task Delay()
        {
            await Task.Delay(1000);
        }


        /// <summary>
        /// Fades the splashscreen in
        /// </summary>
        /// <returns></returns>
        public async Task FadeIn()
        {
            await View.FadeIn(3000);
        }
    }
}
