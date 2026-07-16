using GasketWizard.Attributes;
using GasketWizard.Domain;
using GasketWizard.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace GasketWizard.Databases.StandartSizes.Files
{
    public class FileBasedStandartSizesDb : IStandartSizesDb
    {
        public IEnumerable<PartBase> GetAll(string name)
        {
            Type type = GetPartType(name);

            string group = type.GetCustomAttribute<PartGroupAttribute>().Title;
            string path = GetFilePath(group, name);

            using (StreamReader  sr = new StreamReader(path))
            {
                string[] headers = sr.ReadLine()
                                     .Split(' ')
                                     .RemoveEmptyStrings();
                while(true)
                {
                    string line = sr.ReadLine();
                    if (line == null)
                        break;

                    PartBase part = (PartBase)Activator.CreateInstance(type);

                    PartBase.SetValues(part, line.Split(' '), headers);

                    yield return part;
                }
            }
        }
           

        public PartBase GetById(string id, string name)
        {
            Type type = GetPartType(name);
            PartBase part = (PartBase)Activator.CreateInstance(type);

            string group = type.GetCustomAttribute<PartGroupAttribute>().Title;
            string path = GetFilePath(group, name);

            using (StreamReader sr = new StreamReader(path))
            {
                var headers = sr.ReadLine()
                                .Split(' ')
                                .RemoveEmptyStrings();

                while(true)
                {
                    string line = sr.ReadLine();
                    if (line == null)   
                        break;

                    string[] splitedLine = line.Split(' ')
                                               .RemoveEmptyStrings();

                    if (splitedLine[0] == id)
                    {
                        for (int i = 0; i < headers.Length; i++)
                        {
                            PartBase.SetValue(part, splitedLine[i], headers[i]);
                        }

                        break;
                    }
                }

                sr.Close();
            }

            return part;
        }

        private static string GetRootDirectory()
        {
            var assembly = Assembly.GetExecutingAssembly();

            string path = assembly.Location;

            while(path.Contains("bin") || path.Contains("Debug") || path.Contains("Release"))
            {
                path = Directory.GetParent(path).FullName;
            }

            return path;
        }

        private static string GetFilePath(string group, string name)
        {
            string path = Path.Combine(
                GetRootDirectory(),
                "Databases",
                "StandartSizes",
                "Files",
                group,
                $"{name}.txt"
            );

            return path;
        }

        private static Type GetPartType(string name)
            => Assembly.GetExecutingAssembly()
                       .GetTypes()
                       .First(t => t.Name == name);
    }
}
