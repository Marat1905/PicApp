using PicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoPage : ContentPage
    {
        public PhotoPage(PictureInfo picture)
        {
            InitializeComponent();
            this.BindingContext = picture;
        }
    }
}