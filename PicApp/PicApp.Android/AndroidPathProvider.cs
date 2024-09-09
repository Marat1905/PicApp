using PicApp.Services;
using Xamarin.Forms;


[assembly: Dependency(typeof(PicApp.Droid.AndroidPathProvider))]
namespace PicApp.Droid
{
    public class AndroidPathProvider : IPathProvider
    {
        public string GetPicturesFolderPath()
        {
            return Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).AbsolutePath;
        }
    }
}