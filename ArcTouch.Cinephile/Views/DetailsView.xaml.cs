using ArcTouch.Cinephile.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArcTouch.Cinephile.Entity;
using ArcTouch.Cinephile.IoC;
using ArcTouch.Cinephile.Services;

namespace ArcTouch.Cinephile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsView : BaseView
    {
        public DetailsView()
        {
            InitializeComponent();
        }

        internal void ShowDetails(ImageSource imageSource, string overView, string title, string genres, string releaseDate)
        {
            this.image.Source = imageSource;
            this.overView.Text = overView;
            this.title.Text = title;
            this.genres.Text = genres;
            this.releaseDate.Text = releaseDate;
        }
    }
}