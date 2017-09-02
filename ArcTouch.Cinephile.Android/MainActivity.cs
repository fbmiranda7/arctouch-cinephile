using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Ninject;
using Xamarin.Forms;
using ArcTouch.Cinephile.Native;
using ArcTouch.Cinephile.Droid.Native;

namespace ArcTouch.Cinephile.Droid
{
    [Activity(Label = "TMDb Cinephile", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            InitializeNativeContainer();

            LoadApplication(new App());
        }

        private void InitializeNativeContainer()
        {
            DependencyService.Register<INativeUi, AndroidUi>();
        }
    }
}