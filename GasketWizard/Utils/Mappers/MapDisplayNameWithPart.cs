using GasketWizard.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace GasketWizard.Utils.Mappers
{
    public static class MapDisplayNameWithPart
    {
        private static IEnumerable<Type> _types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.BaseType == typeof(PartBase));

        public static PartBase Map(string displayName)
        {
            Type type = _types
                .FirstOrDefault(t => (t.GetCustomAttribute<DisplayNameAttribute>()).DisplayName == displayName);

            if (type == null)
                return null;

            var obj = Activator.CreateInstance(type);

            return (PartBase)obj;
        }
    }
}
