using GasketWizard.Attributes;
using GasketWizard.Domain.Housing;
using GasketWizard.Domain.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GasketWizard.Domain.Sockets
{
    [PartTitle("SKRO-type gasket socket", "ru-RU:Гнездо сальника типа СКРО")]
    public class SKROGasketSocket : GasketSocket
    {
        [PartParameter("D")]
        public double BigCylinderOutsideDiameter { get; set; }

        [PartParameter("D1")]
        public double SmallCylinderOutsideDiameter { get; set; }

        [PartParameter("d")]
        public double SmallCylinderInsideDiameter { get; set; }

        [PartParameter("L")]
        public double Length { get; set; }

        [PartParameter("l")]
        public double BigCylinderLength { get; set; }

        [PartParameter("Thread", Enums.SizeTypes.Standart, "ru-RU:Резьба")]
        public MetricThread Thread { get; set; }


        [PartParameter("Thread length", Enums.SizeTypes.Custom, "ru-RU:Длина резьбы")]
        public double ThreadLength { get; set; }

        [PartParameter("Big hole thread", Enums.SizeTypes.Custom, "ru-RU:Глубина большего выреза")]
        public double BigHoleLength { get; set; }

        [PartParameter("Big hole diameter", Enums.SizeTypes.Custom, "ru-RU:Диаметр большего выреза")]
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
