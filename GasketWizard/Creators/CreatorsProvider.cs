using GasketWizard.Attributes;
using GasketWizard.Domain;
using Kompas6API5;
using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace GasketWizard.Creators
{
    public static class CreatorsProvider
    {
        public static bool Create(PartBase part, bool save, string savePath)
        {
            KompasObject kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
            IApplication application = kompas.ksGetApplication7();

            IKompasDocument activeDocument = application.ActiveDocument;

            Type partType = part.GetType();

            var targetCreators = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && t.BaseType.Name.Contains(partType.Name));

            var targetCreator = FindCreatorByPartType(partType, targetCreators);

            if (targetCreator == null)
            {
                kompas.ksMessage("Не удается найти подходящий мастер для данной детали!");

                return false;
            }

            var creator = (Creator)Activator.CreateInstance(targetCreator, part, activeDocument);
            bool result = creator.Create();

            if (result && save)
            {
                creator.Save(savePath);
            }

            return result;
        }

        private static Type FindCreatorByPartType(Type partType, IEnumerable<Type> creators)
        {
            KompasObject kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
            IApplication application = kompas.ksGetApplication7();

            IKompasDocument kompasDocument = application.ActiveDocument;

            var modelTypes = partType.GetCustomAttribute<ModelTypeAttributes>().ModelTypes;

            Type creator = null;

            if (kompasDocument is IPartDocument partDocument)
            {
                if (modelTypes.Contains(Enums.ModelType.Part))
                {
                    creator = creators.First(c => c.Name.Contains("Part"));
                }
            }
            else if (kompasDocument is IAssemblyDocument assemblyDocument)
            {
                if (modelTypes.Contains(Enums.ModelType.Assembly))
                {
                    creator = creators.First(c => c.Name.Contains("Assembly"));
                }
            }

            return creator;
        }
    }
}
