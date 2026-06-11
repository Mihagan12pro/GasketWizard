using GasketWizard.Attributes;
using GasketWizard.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace GasketWizard.Databases.StandartSizes.Files
{
    public class FileBasedStandartSizesDb : IStandartSizesDb
    {
        public IEnumerable<PartBase> GetAll(string name)
        {
            Type type = Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .FirstOrDefault(t => t.Name == name);

            PartBase[] parts = null;

            if (type != null)
            {
                string group = type.GetCustomAttribute<PartGroupAttribute>().Group;

                DirectoryInfo rootDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;

                string path = Path.Combine(
                    rootDirectory.FullName, 
                    "Databases", 
                    "StandartSizes", 
                    "Files", 
                    group,
                    $"{name}.txt"
                );

                var lines = File.ReadAllLines(path)
                    .Select(l => l.Split(' ').Where(i => i.Length > 0))
                    .ToArray();

                parts = new PartBase[lines.Length - 1];

                var header = lines[0]
                    .ToArray();

                PropertyInfo[] propertyInfos = new PropertyInfo[type.GetProperties().Length];
                for(int i = 0; i < type.GetProperties().Length; i++)
                {
                    propertyInfos[i] = type.GetProperties()
                        .FirstOrDefault(
                            p => p.GetCustomAttribute<DisplayNameAttribute>().DisplayName == header[i]
                        );
                }

                for(int i = 0; i < parts.Length; i++)
                {
                    PartBase part = (PartBase)Activator.CreateInstance(type);

                    string[] line = lines[i + 1]
                        .ToArray();

                    for(int j = 0; j < line.Length; j++)
                    {
                        PropertyInfo property = propertyInfos[j];

                        object value;

                        if (property.PropertyType == typeof(double))
                        {
                            double.TryParse(line[j], NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out double result);

                            value = result;
                        }
                        else if (property.PropertyType == typeof(int))
                            value = Convert.ToInt32(line[j]);
                        else
                            value = line[j];

                        property.SetValue(part, value);
                    }

                    parts[i] = part;
                }
            }

            return parts;
        }

        public PartBase GetById(int id, string name)
        {
            Type type = Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .First(t => t.Name == name);

            string group = type.GetCustomAttribute<PartGroupAttribute>().Group;

            DirectoryInfo rootDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;

            string path = Path.Combine(
                rootDirectory.FullName,
                "Databases",
                "StandartSizes",
                "Files",
                group,
                $"{name}.txt"
            );

            var header = File.ReadAllLines(path)
                             .ElementAt(0)
                             .Split(' ')
                             .Where(i => i.Length > 0)
                             .ToArray();

            var line = File.ReadLines(path)
                           .ElementAtOrDefault(id)
                           .Split(' ')
                           .Where(i => i.Length > 0)
                           .ToArray();

            PartBase part = (PartBase)Activator.CreateInstance(type); 

            for(int i = 0; i < header.Length; i++)
            {
                PropertyInfo property = type.GetProperties()
                    .First(p => p.GetCustomAttribute<DisplayNameAttribute>().DisplayName == header[i]);

                object value;

                if (property.PropertyType == typeof(double))
                {
                    double.TryParse(line[i], NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out double result);

                    value = result;
                }
                else if (property.PropertyType == typeof(int))
                    value = Convert.ToInt32(line[i]);
                else
                    value = line[i];

                property.SetValue(part, value);
            }

            return part;
        }
    }
}
