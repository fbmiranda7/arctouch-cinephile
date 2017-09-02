using System;
using ArcTouch.Cinephile.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArcTouch.Cinephile.Presenters.Interfaces;
using ArcTouch.Cinephile.Presenters;
using Ninject;
using System.Reflection;
using ArcTouch.Cinephile.IoC;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ArcTouch.Cinephile
{
	public partial class App : Application
	{
        public App()
		{
			InitializeComponent();

            InitializeContainer();

            Bootstrap();
		}

        /// <summary>
        /// Xamarin.Forms bootstrap first page/splashscreen and the first results from the service
        /// </summary>
        private void Bootstrap()
        {
            ISplashPresenter splashPresenter = Resolver.Get<ISplashPresenter>();

            Xamarin.Forms.Application.Current.MainPage = splashPresenter.View;

            splashPresenter.FadeIn()
                .ContinueWith(async t => await splashPresenter.Delay())
                .ContinueWith(t => Xamarin.Forms.Device.BeginInvokeOnMainThread(() => {

                    IUpcomingPresenter upcomingPresenter = Resolver.Get<IUpcomingPresenter>();

                    // wraps within a navigation creating the push/pop stack
                    Application.Current.MainPage = new NavigationPage(upcomingPresenter.View);
                    
                    upcomingPresenter.FetchAndAppend();
                }));
        }

        /// <summary>
        /// Ninject container initialization
        /// </summary>
        private void InitializeContainer()
        {
            StandardKernel kernel = new StandardKernel();
            kernel.Load(typeof(ApplicationModule).GetTypeInfo().Assembly);
        }
	}
}
