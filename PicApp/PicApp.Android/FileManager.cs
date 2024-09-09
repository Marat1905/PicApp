using Android.Content;
using Android.Provider;
using PicApp.Services;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(PicApp.Droid.FileManager))]
namespace PicApp.Droid
{

    internal class FileManager : IFileManager
    {
        public bool DeleteFile(string filePath)
        {
            try
            {
                Context context = Android.App.Application.Context;
                Java.IO.File file = new Java.IO.File(filePath);

                string where = MediaStore.MediaColumns.Data + "=?";
                string[] selectionArgs = new string[] { file.AbsolutePath };
                ContentResolver contentResolver = context.ContentResolver;
                Android.Net.Uri filesUri = MediaStore.Video.Media.InternalContentUri;

                if (file.Exists())
                {
                    contentResolver.Delete(filesUri, where, selectionArgs);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}