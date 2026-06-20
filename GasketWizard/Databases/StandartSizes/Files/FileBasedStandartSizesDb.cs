using GasketWizard.Attributes;
using GasketWizard.Domain;
using GasketWizard.Domain.ValueObjects;
using GasketWizard.Enums;
using GasketWizard.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SizeType = GasketWizard.Enums.SizeType;

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

                PropertyInfo[] propertyInfos = type.GetProperties()
                    .Where(p => p.GetCustomAttribute<SizeTypeAttribute>() != null && p.GetCustomAttribute<SizeTypeAttribute>().SizeType == SizeType.Standart)
                    .ToArray();

                for (int i = 0; i < parts.Length; i++)
                {
                    PartBase part = (PartBase)Activator.CreateInstance(type);

                    string[] line = lines[i + 1]
                        .ToArray();

                    for(int j = 0; j < line.Length; j++)
                    {
                        PartBase.SetValue(part, line[j], header[j]);
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
                PartBase.SetValue(part, line[i], header[i]);
            }

            return part;
        }
    }
}
