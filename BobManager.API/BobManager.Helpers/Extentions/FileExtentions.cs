using System;
using System.IO;

namespace BobManager.Helpers.Extentions
{
    public static class FileExtentions
    {
        public static void CreateWithDirectories(string path) {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            string fullPath = Path.GetFullPath(path);
            Directory.CreateDirectory(fullPath.Substring(0, fullPath.LastIndexOf('\\')));
            File.Create(path).Close();
        }
    }
}