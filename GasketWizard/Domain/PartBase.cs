using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

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
                .FirstOrDefault(t => t.GetCustomAttribute<DisplayNameAttribute>().DisplayName == displayName);
        }

        public static Bitmap MapDisplayNameWithBitmap(string displayName)
        {
            Bitmap bitmap = null;

            try
            {
                var assembly = Assembly.GetExecutingAssembly();

                var partType = assembly.GetTypes()
                    .FirstOrDefault(t => t.GetCustomAttribute<DisplayNameAttribute>().DisplayName == displayName);

                if (partType == null)
                    return Resource.Default;

                bitmap = (Bitmap)Resource.ResourceManager.GetObject(partType.Name);

                if (bitmap == null)
                    return Resource.Default;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex}");
            }

            return bitmap;
        }
    }
}
