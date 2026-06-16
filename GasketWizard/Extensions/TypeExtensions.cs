using System;
using System.ComponentModel;
using System.Reflection;

namespace GasketWizard.Extensions
{
    public static class TypeExtensions
    {
        public static string GetDisplayName(this Type type)
           => type.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
    }
}
