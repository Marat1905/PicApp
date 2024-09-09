using PicApp.Services;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(PicApp.UWP.WindowsPathProvider))]
namespace PicApp.UWP
{
    public class WindowsPathProvider : IPathProvider
    {
        public string GetPicturesFolderPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        }
    }
}
