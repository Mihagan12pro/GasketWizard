using GasketWizard.Attributes;
using GasketWizard.Domain.ValueObjects;
using GasketWizard.Enums;
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
        [PartParameter("№")]
        public int Id { get; set; }

        public bool HasErrors
        {
            get
            {
                _errors.Clear();

                var results = new List<ValidationResult>();
                var context = new ValidationContext(this);

                _errors.AddRange(Validate(context).Select(e => e.ErrorMessage));

                return _errors.Count() > 0;
            }
        }

        public IReadOnlyList<string> Errors
            => _errors.AsReadOnly();

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
                                        .First(p => p.GetCustomAttribute<PartParameterAttribute>().Title == header);

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
        {
            _errors.Clear();

            List<ValidationResult> errors = new List<ValidationResult>();

            PropertyInfo[] props = this.GetType()
                .GetProperties()
                .Where(p => p.GetCustomAttribute<PartParameterAttribute>() != null && p.GetCustomAttribute<PartParameterAttribute>().SizeType == SizeTypes.Custom)
                .ToArray();

            foreach(var  prop in props)
            {
                if (0 == (double)prop.GetValue(this))
                    errors.Add(new ValidationResult($"Параметр '{prop.GetCustomAttribute<PartParameterAttribute>().LocalizedTitle}' должен быть строго больше нуля!"));
            }

            return errors;
        }

        private List<string> _errors = new List<string>();
    }
}
