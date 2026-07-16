using GasketWizard.Attributes;
using GasketWizard.Domain.Housing;
using GasketWizard.Domain.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;

namespace GasketWizard.Domain.Sockets
{
    [PartTitle("SKSO-type gasket socket", "ru-RU:Гнездо сальника типа СКСО")]
    public class SKSOGasketSocket : GasketSocket
    {
        [PartParameter("Thread", Enums.SizesTypes.Standart, "ru-RU:Резьба")]
        public MetricThread Thread { get; set; }

        [PartParameter("D")]
        public double Diameter { get; set; }

        [PartParameter("L")]
        public double Length { get; set; }

        [PartParameter("Chamfer angle", Enums.SizesTypes.Custom, "ru-RU:Угол фаски")]
        public double Angle { get; set; } = 45;

        [PartParameter("Chamfer distance", Enums.SizesTypes.Custom, "ru-RU:Длина фаски")]
        public double ChamferLength { get; set; } = 1;

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = base.Validate(validationContext).ToList();

            if (Angle <= 0 || Angle >= 90)
            {
                errors.Add(new ValidationResult("Угол фаски должен быть больше 0 и меньше 90!"));
            }

            return errors;
        }
    }
}
