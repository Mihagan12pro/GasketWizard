using GasketWizard.Domain;
using Kompas6API5;
using KompasAPI7;
using System;
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

            Type partType = part.GetType();

            var targetCreators = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && t.BaseType.Name.Contains(partType.Name));

            IKompasDocument kompasDocument = application.ActiveDocument;

            if (kompasDocument is IPartDocument partDoc)
            {
                var targetCreator = targetCreators.First(c => c.Name.Contains("Part"));

                var creator = (Creator)Activator.CreateInstance(targetCreator, part, partDoc);

                creator.Create();

                if (save)
                    creator.Save(savePath);
            }
            else if ((kompasDocument is IAssemblyDocument assemblyDoc))
            {
                var targetCreator = targetCreators.First(c => c.Name.Contains("Assembly"));

                var creator = Activator.CreateInstance(targetCreator, assemblyDoc);
            }

            return false;
        }
    }
}
