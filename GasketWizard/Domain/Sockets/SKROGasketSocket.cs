using GasketWizard.Attributes;
using GasketWizard.Domain.Housing;
using GasketWizard.Domain.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GasketWizard.Domain.Sockets
{
    [DisplayName("Гнездо сальника типа СКРО")]
    public class SKROGasketSocket : GasketSocket
    {
        [DisplayName("D")]
        [SizeTypes(Enums.SizeTypes.Standart)]
        public double BigCylinderOutsideDiameter { get; set; }

        [DisplayName("D1")]
        [SizeTypes(Enums.SizeTypes.Standart)]
        public double SmallCylinderOutsideDiameter { get; set; }

        [DisplayName("d")]
        [SizeTypes(Enums.SizeTypes.Standart)]
        public double SmallCylinderInsideDiameter { get; set; }

        [DisplayName("L")]
        [SizeTypes(Enums.SizeTypes.Standart)]
        public double Length { get; set; }

        [DisplayName("l")]
        [SizeTypes(Enums.SizeTypes.Standart)]
        public double BigCylinderLength { get; set; }

        [DisplayName("Резьба")]
        [SizeTypes(Enums.SizeTypes.Standart)]
        public MetricThread Thread { get; set; }


        [DisplayName("Длина резьбы")]
        [SizeTypes(Enums.SizeTypes.Custom)]
        public double ThreadLength { get; set; }

        [DisplayName("Глубина большего выреза")]
        [SizeTypes(Enums.SizeTypes.Custom)]
        public double BigHoleLength { get; set; }

        [DisplayName("Диаметр большего выреза")]
        [SizeTypes(Enums.SizeTypes.Custom)]
        public double BigHoleDiameter { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = base.Validate(validationContext).ToList();

            if (BigHoleDiameter >= BigCylinderOutsideDiameter)
                result.Add(new ValidationResult("Параметр 'Диаметр большего выреща' должен быть меньше D!"));

            if (BigHoleLength >= BigCylinderLength)
                result.Add(new ValidationResult("Параметр 'Глубина большего выреза' должен быть меньше l!"));

            if (ThreadLength > BigHoleLength)
                result.Add(new ValidationResult("Параметр 'Глубина большего выреза' должен быть больше или равен параметру 'Длина резьбы'!"));

            return result;
        }
    }
}
