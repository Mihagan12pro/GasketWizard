using System.Linq;

namespace GasketWizard.Extensions
{
    public static class ArrayExtensions
    {
        public static string[] RemoveEmptyStrings(this string[] array)
             => array.Where(i => i != string.Empty).ToArray();
    }
}
