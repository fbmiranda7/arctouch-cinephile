using ArcTouch.Cinephile.Base;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcTouch.Cinephile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SplashView : BaseView
	{
		public SplashView()
		{
            InitializeComponent();
        }

        public async Task FadeIn(uint length)
        {
            powered.FadeTo(1, length, Easing.Linear);
            await bg.FadeTo(1, length, Easing.Linear);
        }
    }
}