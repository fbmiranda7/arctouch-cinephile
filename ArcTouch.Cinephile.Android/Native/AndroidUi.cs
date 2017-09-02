using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ArcTouch.Cinephile.Native;

namespace ArcTouch.Cinephile.Droid.Native
{
    /// <summary>
    /// Wraps any specific native code for Android
    /// </summary>
    public class AndroidUi : INativeUi
    {
        public void DisplayTooltip(string text)
        {
            Toast.MakeText(Xamarin.Forms.Forms.Context, text, ToastLength.Short)
                .Show();
        }
    }
}