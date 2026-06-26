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


        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (HexagonHeight <= 0)
            {
                errors.Add(new ValidationResult("Высота шестиугольника гайки должна быть больше нуля!"));
            }

            if (ThreadLength <= 0)
            {
                errors.Add(new ValidationResult("Длина резьбы гайки должна быть больше нуля!"));
            }

            if (ChamferLength <= 0)
            {
                errors.Add(new ValidationResult("Длина фаски должна быть больше нуля!"));
            }

            return errors;
        }
    }
}
