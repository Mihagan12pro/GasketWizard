using GasketWizard.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace GasketWizard.Mappers
{
    public static class PartTypeMapper
    {
        public static Type MapDisplayName(string displayName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            return assembly.GetTypes()
                .Where(t => t.GetCustomAttribute<PartTitleAttribute>() != null)
                .FirstOrDefault(t => t.GetCustomAttribute<PartTitleAttribute>().LocalizedTitle == displayName);
        }
    }
}
