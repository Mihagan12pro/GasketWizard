using GasketWizard.Attributes;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GasketWizard.Creators.Nuts
{
    [DisplayName("Нажимная гайка, исполнение 1")]
    public class ClumpingNut1 : ClumpingNut
    {
        [SizeType(Enums.SizeType.Custom)]
        [DisplayName("Высота шестиугольника")]
        public double HexagonHeight { get; set; }

        [SizeType(Enums.SizeType.Custom)]
        [DisplayName("Длина резьбы")]
        public double ThreadLength { get; set; }

        [SizeType(Enums.SizeType.Custom)]
        [DisplayName("Длина фаски")]
        public double ChamferLength { get; set; }

        [SizeType(Enums.SizeType.Custom)]
        [DisplayName("Диаметр большего цилиндра")]
        public double BigCylinderDiameter { get; set; }

        [SizeType(Enums.SizeType.Custom)]
        [DisplayName("Диаметр меньшего цилиндра")]
        public double LessCylinderDiameter { get; set; }


        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (LessCylinderDiameter <= 0)
            {
                errors.Add(new ValidationResult("Диаметр меньшего цилиндра должен быть больше нуля!"));
            }

            if (HexagonHeight <= 0)
            {
                errors.Add(new ValidationResult("Высота шестиугольника гайки должна быть больше нуля!"));
            }

            if ( BigCylinderDiameter <= 0)
            {
                errors.Add(new ValidationResult("Диаметр большего цилиндра должен быть больше нуля!"));
            }

            if (ThreadLength <= 0)
            {
                errors.Add(new ValidationResult("Длина резьбы гайки должна быть больше нуля!"));
            }

            if (ChamferLength <= 0)
            {
                errors.Add(new ValidationResult("Длина фаски должна быть больше нуля!"));
            }

            if (HexagonHeight + ThreadLength >= Length)
            {
                errors.Add(new ValidationResult("Длина резьбы и высота шестиугольника не должны быть в сумме больше длины гайки!"));
            }

            return errors;
        }
    }
}
