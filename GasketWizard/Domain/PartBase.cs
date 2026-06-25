using GasketWizard.Attributes;
using GasketWizard.Domain.ValueObjects;
using GasketWizard.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace GasketWizard.Domain
{
    /// <summary>
    /// Describes part parameters and provides validation
    /// </summary>
    public abstract class PartBase : IValidatableObject
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

        public static void SetValues(PartBase part, string[] line, string[] headers)
        {
            for (int i = 0; i < headers.Length; i++)
            {
                PartBase.SetValue(part, line[i], headers[i]);
            }
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

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            => new List<ValidationResult>();    
    }
}
