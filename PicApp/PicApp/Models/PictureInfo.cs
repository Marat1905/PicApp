using System;

namespace PicApp.Models
{
    /// <summary>Информация о файле </summary>
    public class PictureInfo
    {
        /// <summary>Имя файла</summary>
        public string NameFile { get; set; }

        /// <summary>Путь к файлу</summary>
        public string PathToPicture {  get; set; }

        /// <summary>Дата создания файла</summary>
        public DateTime CreateDate { get; set; }

        public PictureInfo(string nameFile, string pathToPicture, DateTime createDate)
        {
            NameFile = nameFile;
            PathToPicture = pathToPicture;
            CreateDate = createDate;
        }
    }
}
