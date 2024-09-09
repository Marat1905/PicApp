using PicApp.Models;
using PicApp.Services;
using PicApp.ViewModels.Base;
using PicApp.Views;
using System;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;

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

        /// <summary>Выбранное изображение</summary>
        private PictureInfo _selectedPicture;

        /// <summary>Выбранное изображение</summary>
        public PictureInfo SelectedPicture
        {
            get { return _selectedPicture; }
            set { SetProperty(ref _selectedPicture, value); }
        }

        public Command OpenPicrureCommand { get; }

        public Command RemovePictureCommand { get; }

        public GalleryViewModel()
        {
            Title = "Галерея";
            IPathProvider pathProvider = DependencyService.Get<IPathProvider>();
            picturesPath = pathProvider.GetPicturesFolderPath();
            bool isExist = Directory.Exists(picturesPath);
            OpenPicrureCommand = new Command(OpenPicrureClicked);
            RemovePictureCommand = new Command(RemovePictureClicked);
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

        private async void OpenPicrureClicked(object obj)
        {
            if (SelectedPicture is null)
                return;

            await Application.Current.MainPage.Navigation.PushAsync(new PhotoPage(SelectedPicture));
        }

        private async void RemovePictureClicked(object obj)
        {
            if (SelectedPicture is null)
                return;

            var answer = await Application.Current.MainPage.DisplayAlert("Внимание!", $"Удалить {SelectedPicture.NameFile}", "Да", "Нет");

            if (answer == false)
            {
                return;
            }

            try
            {
                if (File.Exists(SelectedPicture.PathToPicture))
                {
                    File.Delete(SelectedPicture.PathToPicture);
                }
                PictureList.Remove(SelectedPicture);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка!", ex.Message, "OK");
            }
        }
    }
}
