using GasketWizard.Domain;
using System;
using System.Drawing;
using System.Globalization;
using System.Resources;

namespace GasketWizard.Utils.Mappers
{
    public static class MapPartWithSketch
    {
        public static Bitmap Map(PartBase part)
        {
            Type type = part.GetType();

            ResourceSet resources = Resource.ResourceManager.GetResourceSet(
                CultureInfo.InvariantCulture,
                false,
                false);

            var resource = resources.GetObject(type.Name, true);

            if (resource == null || resource.GetType() != typeof(Bitmap))
                throw new InvalidOperationException("Not found!");

            return (Bitmap)resource;
        }
    }
}
