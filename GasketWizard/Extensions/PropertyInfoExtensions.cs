using System.ComponentModel;
using System.Reflection;

namespace GasketWizard.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static string GetDisplayName(this PropertyInfo property)
            => property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
    }
}
