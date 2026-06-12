using GasketWizard.Domain;
using Kompas6API5;
using Kompas6Constants3D;
using KompasAPI7;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GasketWizard.Creators
{
    public static class CreatorsProvider
    {
        public static object FindCreator(PartBase part)
        {
            Type creatorsInterface = typeof(ICreator<>);

            var targetCreators = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces()
                                          .Any(i => i.IsGenericType && 
                                           i.GetGenericTypeDefinition() == creatorsInterface));
            
            KompasObject kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
            IApplication application = kompas.ksGetApplication7();

            if (application.ActiveDocument == null)
            {
                throw new NullReferenceException("No active documents!");
            }

            IKompasDocument kompasDocument = application.ActiveDocument;

            if (kompasDocument is IPartDocument partDoc)
            {
                var targetCreator = targetCreators.First(c => c.Name.Contains("Part"));
                
                return Activator.CreateInstance(targetCreator, partDoc);
            }
            else if ((kompasDocument is IAssemblyDocument assemblyDoc))
            {
                var targetCreator = targetCreators.First(c => c.Name.Contains("Assembly"));

                return Activator.CreateInstance(targetCreator, assemblyDoc);
            }

            return null;
        }
    }
}
