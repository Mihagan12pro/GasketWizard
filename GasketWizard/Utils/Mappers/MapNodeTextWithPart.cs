using GasketWizard.Domain;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace GasketWizard.Utils.Mappers
{
    public static class MapNodeTextWithPart
    {
        public static PartBase Map(string nodeText)
        {
            Type type = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.BaseType == typeof(PartBase))
                .First(t => ((DisplayNameAttribute)t.GetCustomAttribute<DisplayNameAttribute>()).DisplayName == nodeText);

            var obj = Activator.CreateInstance(type);

            return (PartBase)obj;
        }
    }
}
