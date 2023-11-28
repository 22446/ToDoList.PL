using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ToDoList.PL.Helper
{
    public static class DocumentSetting
    {
        public static string UploadFile(IFormFile file, string FolderName)
        {

            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);
            var FileName = $"{Guid.NewGuid()} {file.FileName}";
            var FilePath = Path.Combine(FolderPath, FileName);
            using var Fs = new FileStream(FilePath, FileMode.Create);
            file.CopyTo(Fs);
            return FileName;


        }
        public static void DeleteFile(string FileName , string FolderName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
