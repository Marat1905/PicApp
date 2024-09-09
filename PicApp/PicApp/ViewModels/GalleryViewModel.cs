using PicApp.Services;
using System.IO;
using Xamarin.Forms;

namespace PicApp.ViewModels
{
    internal class GalleryViewModel
    {
        public GalleryViewModel()
        {
            IPathProvider pathProvider = DependencyService.Get<IPathProvider>();
            string picturesPath = pathProvider.GetPicturesFolderPath();
            bool isExist = Directory.Exists(picturesPath);
        }
    }
}
