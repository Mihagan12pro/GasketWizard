using GasketWizard.Attributes;
using GasketWizard.Domain;
using GasketWizard.Domain.ValueObjects;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace GasketWizard.Extensions
{
    public static class KompasModelExtensions
    {
        public static void SetValues(this KompasModel model, string[] line, string[] headers)
        {
            for (int i = 0; i < headers.Length; i++)
            {
                SetValue(model, line[i], headers[i]);
            }
        }

        public static void SetValue(this KompasModel model, string lineValue, string header)
        {
            PropertyInfo property = model.GetType()
                                        .GetProperties()
                                        .Where(p => p.GetCustomAttribute<PartParameterAttribute>() != null)
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
                else if (property.PropertyType.GetInterface(nameof(IValueObject)) != null)
                {
                    value = Activator.CreateInstance(property.PropertyType, lineValue);
                }
                else
                {
                    value = lineValue;
                }

                property.SetValue(model, value);
            }
        }
    }
}
