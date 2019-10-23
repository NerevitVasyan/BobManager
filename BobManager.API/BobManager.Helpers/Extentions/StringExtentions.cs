using System;
using System.Collections.Generic;
using System.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace BobManager.Helpers.Extentions
{
    public static class StringExtensions
    {
        public static bool PathEquals(this string path1, string path2)
        {
            return Path.GetFullPath(path1)
                .Equals(Path.GetFullPath(path2), StringComparison.InvariantCultureIgnoreCase);
        }

        public static string ExceptionFormatter<TState>(TState state, Exception e) {
            return e.Message;
        }
    }
}
