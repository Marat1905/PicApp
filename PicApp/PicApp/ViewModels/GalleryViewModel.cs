using PicApp.Models;
using PicApp.Services;
using PicApp.ViewModels.Base;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace PicApp.ViewModels
{
    internal class GalleryViewModel : BaseViewModel
    {
        /// <summary>Путь к каталогу </summary>
        private readonly string picturesPath;

        /// <summary>Коллекция изображений</summary>
        private ObservableCollection<PictureInfo> _pictureList = new ObservableCollection<PictureInfo>();

        /// <summary>Коллекция изображений</summary>
        public ObservableCollection<PictureInfo> PictureList
        {
            get { return _pictureList; }
            set { SetProperty(ref _pictureList, value); }
        }



        public GalleryViewModel()
        {
            Title = "Галерея";
            IPathProvider pathProvider = DependencyService.Get<IPathProvider>();
            picturesPath = pathProvider.GetPicturesFolderPath();
            bool isExist = Directory.Exists(picturesPath);
            InitializeData();
        }

        private void InitializeData()
        {
            LoadPictureList();
        }

        private async void LoadPictureList()
        {
           if(string.IsNullOrEmpty(picturesPath) || !Directory.Exists(picturesPath))
                return;

            DirectoryInfo dir = new DirectoryInfo(picturesPath);

            var files = dir.GetFileSystemInfos("*.jpg");

            foreach (var file in files)
            {
                _pictureList.Add(new PictureInfo(file.Name, file.FullName, file.CreationTime));
            }
        }
    }
}
