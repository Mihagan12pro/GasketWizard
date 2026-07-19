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
    public abstract class PartBase : KompasModel<int>
    {
        [PartParameter("№")]
        public int Id { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            this.errors.Clear();

            List<ValidationResult> errors = new List<ValidationResult>();

            PropertyInfo[] props = this.GetType()
                .GetProperties()
                .Where(p => p.GetCustomAttribute<PartParameterAttribute>() != null && p.GetCustomAttribute<PartParameterAttribute>().SizeType == SizesTypes.Custom)
                .ToArray();

            foreach (var prop in props)
            {
                if (0 == (double)prop.GetValue(this))
                    errors.Add(new ValidationResult($"Параметр '{prop.GetCustomAttribute<PartParameterAttribute>().LocalizedTitle}' должен быть строго больше нуля!"));
            }

            return errors;
        }

        public override object GetId()
            => Id;
    }
}
