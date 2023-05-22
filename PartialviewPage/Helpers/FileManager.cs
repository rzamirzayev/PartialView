﻿using PartialviewPage.Models;
using System.IO;

namespace PustokTemplate.Helpers
{
    public static class FileManager
    {
        public static string Save(string rootPath, string folder, IFormFile file)
        {
            string newFileName = Guid.NewGuid().ToString() + (file.FileName.Length <= 64 ? file.FileName : (file.FileName.Substring(file.FileName.Length - 64)));
            string path = Path.Combine(rootPath, folder, newFileName);
            using (FileStream str = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(str);
            }

            return newFileName;
        }

        public static bool Delete(string rootPath, string folder, string fileName)
        {
            string path = Path.Combine(rootPath, folder, fileName);

            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }
    }
}
