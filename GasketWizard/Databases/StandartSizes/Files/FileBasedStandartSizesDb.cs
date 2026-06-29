using GasketWizard.Attributes;
using GasketWizard.Domain;
using GasketWizard.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GasketWizard.Databases.StandartSizes.Files
{
    public class FileBasedStandartSizesDb : IStandartSizesDb
    {
        public IEnumerable<PartBase> GetAll(string name)
        {
            Type type = GetPartType(name);

            string group = type.GetCustomAttribute<PartGroupAttribute>().Group;
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

                    string[] splitedLine = line.Split(' ');
                    int.TryParse(splitedLine[0], out int res);

                    PartBase part = (PartBase)Activator.CreateInstance(type);

                    PartBase.SetValues(part, splitedLine, headers);

                    yield return part;
                }
            }
        }
           

        public PartBase GetById(int id, string name)
        {
            Type type = GetPartType(name);
            PartBase part = (PartBase)Activator.CreateInstance(type);

            string group = type.GetCustomAttribute<PartGroupAttribute>().Group;
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

                    int.TryParse(splitedLine[0], out int res);

                    if (res == id)
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
            => Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

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
