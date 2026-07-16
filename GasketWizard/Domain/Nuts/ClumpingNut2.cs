using GasketWizard.Attributes;
using GasketWizard.Creators.Nuts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GasketWizard.Domain.Nut
{
    [PartTitle("Clumping nut, second embodiment", "ru-RU:Нажимная гайка, исполнение 2")]
    public class ClumpingNut2 : ClumpingNut
    {
        [PartParameter("Left cylinder length", Enums.SizesTypes.Custom, "ru-RU:Длина левого цилиндра")]
        public double LeftCylinderLength { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors =  (List<ValidationResult>)base.Validate(validationContext);

            if (LeftCylinderLength < ThreadLength)
            {
                errors.Add(new ValidationResult("Длина резьбы и не должна превышать длину левого цилиндра!"));
            }

            if (LeftCylinderDiameter <= RightCylinderDiameter)
            {
                errors.Add(new ValidationResult("Диаметр левого цилиндра должен быть срого меньше правого!"));
            }

            if (WidthAcrossCorners <= LeftCylinderDiameter)
            {
                errors.Add(new ValidationResult("Параметр D должен быть превышать диаметр левого цилиндра!"));
            }

            if (NominalShaftDiameter >= RightCylinderDiameter)
            {
                errors.Add(new ValidationResult("Параметр d не должен превышать диаметр правого цилиндра!"));
            }

            if (HexagonHeight + LeftCylinderLength >= Length)
            {
                errors.Add(new ValidationResult("Сумма высот левого цилиндра и высоты шестиугольника должна быть меньше длины гайки!"));
            }

            return errors;
        }
    }
}
