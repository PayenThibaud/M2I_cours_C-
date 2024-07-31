using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP02Hotel.Classes
{
    internal static class MyExtensions
    {
        public static bool IsInt32(this string source)
        {
            return Int32.TryParse(source, out int _);
        }

        public static string ToCapitalized(this string source) => source.Substring(0, 1).ToUpper() + source.Substring(1).ToLower();
    }
}
