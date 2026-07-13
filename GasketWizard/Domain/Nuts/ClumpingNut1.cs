using GasketWizard.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GasketWizard.Creators.Nuts
{
    [PartTitle("Clumping nut, first embodiment", "ru-RU:Нажимная гайка, исполнение 1")]
    public class ClumpingNut1 : ClumpingNut
    {
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = base.Validate(validationContext).ToList();

            if (HexagonHeight + ThreadLength >= Length)
            {
                errors.Add(new ValidationResult("Длина резьбы и высота шестиугольника не должны быть в сумме больше длины гайки!"));
            }

            if (RightCylinderDiameter >= WidthAcrossCorners)
            {
                errors.Add(new ValidationResult("Параметр «Диаметр правого цилиндра» не должен превышать стандартный размер D!"));
            }

            if (RightCylinderDiameter <= LeftCylinderDiameter)
            {
                errors.Add(new ValidationResult("Параметр «Диаметр правого цилиндра» должен быть строго больше параметра «Диаметр левого цилиндра»!"));
            }

            if (LeftCylinderDiameter <= NominalShaftDiameter)
            {
                errors.Add(new ValidationResult("Параметр «Диаметр левого цилиндра» должен быть строго больше параметра «d»!"));
            }

            return errors;
        }
    }
}
