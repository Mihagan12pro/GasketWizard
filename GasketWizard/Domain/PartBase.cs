using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace GasketWizard.Domain
{
    public abstract class PartBase
    {
        [DisplayName("№")]
        public int Id { get; set; }

        public static Type MapDisplayNameWithPartType(string displayName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            return assembly.GetTypes()
                .Where(t => t.GetCustomAttribute<DisplayNameAttribute>() != null)
                .FirstOrDefault(t => t.GetCustomAttribute<DisplayNameAttribute>().DisplayName == displayName);
        }

        public static Bitmap MapDisplayNameWithBitmap(string displayName)
        {
            Bitmap bitmap = null;

            var assembly = Assembly.GetExecutingAssembly();

            var partType = assembly.GetTypes()
                .Where(t => t.GetCustomAttribute<DisplayNameAttribute>() != null)
                .FirstOrDefault(t => t.GetCustomAttribute<DisplayNameAttribute>().DisplayName == displayName);

            if (partType == null)
                return Resource.Default;

            bitmap = (Bitmap)Resource.ResourceManager.GetObject(partType.Name);

            if (bitmap == null)
                return Resource.Default;

            return bitmap;
        }
    }
}
