using System;
using System.IO;
namespace BobManager.Helpers.Extentions
{
    public static class StringExtensions
    {
        public static bool PathEquals(this string path1, string path2)
            => Path.GetFullPath(path1)
                .Equals(Path.GetFullPath(path2), StringComparison.InvariantCultureIgnoreCase);
        public static string ExceptionFormatter<TState>(TState state, Exception e) 
            => "[" + DateTime.Now.ToString() + "]: " + e.Message;
    }
}