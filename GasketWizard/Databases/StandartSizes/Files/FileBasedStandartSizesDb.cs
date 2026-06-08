using GasketWizard.Attributes;
using GasketWizard.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GasketWizard.Databases.StandartSizes.Files
{
    public class FileBasedStandartSizesDb : IStandartSizesDb
    {
        public Dictionary<string, List<string>> GetAll(string name)
        {
            Dictionary<string, List<string>> keyValues = new Dictionary<string, List<string>>();

            Type type = Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .FirstOrDefault(t => t.Name == name);

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
                FileInfo sizesFile = new FileInfo(path);
                
                using (StreamReader  reader = new StreamReader(sizesFile.FullName))
                {
                    var headers = reader.ReadLine()
                        .Split(' ')
                        .ToList();

                    headers.RemoveAll(EmptyString);

                    foreach (string header in headers)
                    {
                        keyValues.Add(header, new List<string>());
                    }

                    foreach(string line in reader.ReadToEnd().Replace("\r","").Split('\n'))
                    {
                        var numbers = line.Split(' ').ToList();

                        numbers.RemoveAll(EmptyString);

                        for(int i = 0; i < headers.Count; i++)
                        {
                            keyValues[headers[i]].Add(numbers[i]);
                        }
                    }

                    reader.Close();
                }
            }

            return keyValues;
        }

        private bool EmptyString(string s)
            => s.Length == 0;
    }
}
