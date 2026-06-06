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
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly
                .GetTypes()
                .Where(t => t.BaseType == typeof(PartBase))
                .FirstOrDefault(t => (t.GetCustomAttribute<DisplayNameAttribute>()).DisplayName == nodeText);

            if (type == null)
                return null;

            var obj = Activator.CreateInstance(type);

            return (PartBase)obj;
        }
    }
}
