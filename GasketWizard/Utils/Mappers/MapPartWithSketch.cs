using GasketWizard.Domain;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace GasketWizard.Utils.Mappers
{
    public static class MapPartWithSketch
    {
        public static Bitmap Map(string nodeText)
        {
            var part = MapDisplayNameWithPart.Map(nodeText);

            return Map(part);
        }

        public static Bitmap Map(PartBase part)
        {
            Bitmap bitmap = null;

            try
            {
                Type type = part.GetType();

                ResourceSet resources = Resource.ResourceManager.GetResourceSet(
                    CultureInfo.InvariantCulture,
                    false,
                    false);

                var resource = resources.GetObject(type.Name, true);
                if (resource == null || resource.GetType() != typeof(Bitmap))
                    throw new InvalidOperationException("Not found!");

                bitmap = (Bitmap)resource;
            }
            catch (NullReferenceException)
            {
                bitmap = Resource.Default;
            }

            return bitmap;
        }
    }
}
