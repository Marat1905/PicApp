using PicApp.Services;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(PicApp.iOS.iOSPathProvider))]
namespace PicApp.iOS
{
    public class iOSPathProvider : IPathProvider
    {
        public string GetPicturesFolderPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        }
    }
}