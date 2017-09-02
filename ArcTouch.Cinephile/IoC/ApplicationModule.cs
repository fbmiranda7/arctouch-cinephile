using ArcTouch.Cinephile.Presenters;
using ArcTouch.Cinephile.Presenters.Interfaces;
using ArcTouch.Cinephile.Services;
using ArcTouch.Cinephile.Views;
using Ninject;
using Ninject.Modules;

namespace ArcTouch.Cinephile
{
    /// <summary>
    /// Ninject container, defining respective interfaces/classes and constructors
    /// </summary>
    public class ApplicationModule : NinjectModule
    {
        public static ApplicationModule Instance { get; private set; }

        public ApplicationModule()
        {
            Instance = this;
        }

        /// <summary>
        /// Helper to access the internal Ninject Kernel
        /// </summary>
        private new StandardKernel Kernel
        {
            get
            {
                return base.Kernel as StandardKernel;
            }
        }

        /// <summary>
        /// Called later when App.InitializeContainer is called
        /// </summary>
        public override void Load()
        {
            // Providers
            Bind<IMovieProvider>().To<TMDbProvider>()
                .InSingletonScope();

            // Views
            Bind<SplashView>().To<SplashView>();
            Bind<UpcomingView>().To<UpcomingView>();
            Bind<DetailsView>().To<DetailsView>();

            // Presenters
            Bind<ISplashPresenter>().To<SplashPresenter>()
                .InSingletonScope()
                .WithConstructorArgument<SplashView>(Kernel.Get<SplashView>());

            Bind<IUpcomingPresenter>().To<UpcomingPresenter>()
                .InSingletonScope()
                .WithConstructorArgument<UpcomingView>(Kernel.Get<UpcomingView>())
                .WithConstructorArgument<IMovieProvider>(Kernel.Get<IMovieProvider>());

            Bind<IDetailsPresenter>().To<DetailsPresenter>()
                .InSingletonScope()
                .WithConstructorArgument<DetailsView>(Kernel.Get<DetailsView>());
        }
    }
}
