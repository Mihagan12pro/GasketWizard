using GasketWizard.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GasketWizard.Mappers
{
    public static class BitmapMapper
    {
        public static Bitmap MapDisplayName(string displayName)
        {
            Bitmap bitmap = null;

            var assembly = Assembly.GetExecutingAssembly();

            var partType = assembly.GetTypes()
                .Where(t => t.GetCustomAttribute<PartTitleAttribute>() != null)
                .FirstOrDefault(t => t.GetCustomAttribute<PartTitleAttribute>().LocalizedTitle == displayName);

            if (partType == null)
                return Resource.Default;

            bitmap = (Bitmap)Resource.ResourceManager.GetObject(partType.Name);

            if (bitmap == null)
                return Resource.Default;

            return bitmap;
        }
    }
}
