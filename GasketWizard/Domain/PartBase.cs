using GasketWizard.Attributes;
using GasketWizard.Domain.ValueObjects;
using GasketWizard.Extensions;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GasketWizard.Domain
{
    public abstract class PartBase
    {
        [DisplayName("№")]
        [SizeType()]
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

        public static void SetValue(PartBase part, string lineValue, string header)
        {
            PropertyInfo property = part.GetType()
                                        .GetProperties()
                                        .First(p => p.GetDisplayName() == header);

            if (property != null)
            {
                object value;

                if (property.PropertyType == typeof(double))
                {
                    double.TryParse(lineValue, NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out double result);

                    value = result;
                }
                else if (property.PropertyType == typeof(int))
                {
                    value = Convert.ToInt32(lineValue);
                }
                else if (property.PropertyType.BaseType == typeof(ValueObject))
                {
                    value = Activator.CreateInstance(property.PropertyType, lineValue);
                }
                else
                {
                    value = lineValue;
                }

                property.SetValue(part, value);
            }
        }
    }
}
