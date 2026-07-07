using GasketWizard.Attributes;
using GasketWizard.Enums;
using GasketWizard.Extensions;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace GasketWizard.Creators.Nuts
{
    [PartTitle("Clumping nut, first embodiment", "ru-RU:Нажимная гайка, исполнение 1")]
    public class ClumpingNut1 : ClumpingNut
    {
        [PartParameter("Hexagon height", Enums.SizeTypes.Custom, "ru-RU:Высота шестиугольника")]
        public double HexagonHeight { get; set; }

        [PartParameter("Thread length", Enums.SizeTypes.Custom, "ru-RU:Длина резьбы")]
        public double ThreadLength { get; set; }

        [PartParameter("Chamfer length", Enums.SizeTypes.Custom, "ru-RU:Длина фаски")]
        public double ChamferLength { get; set; }

        [PartParameter("Big cylinder diameter", Enums.SizeTypes.Custom, "ru-RU:Диаметр большего цилиндра")]
        public double BigCylinderDiameter { get; set; }

        [PartParameter("Less cylinder diameter", Enums.SizeTypes.Custom, "ru-RU:Диаметр меньшего цилиндра")]
        public double LessCylinderDiameter { get; set; }


        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = base.Validate(validationContext).ToList();

            if (HexagonHeight + ThreadLength >= Length)
            {
                errors.Add(new ValidationResult("Длина резьбы и высота шестиугольника не должны быть в сумме больше длины гайки!"));
            }

            if (BigCylinderDiameter >= WidthAcrossCorners)
            {
                errors.Add(new ValidationResult("Параметр «Диаметр большего цилиндра» не должен превышать стандартный размер D!"));
            }

            if (LessCylinderDiameter >= BigCylinderDiameter)
            {
                errors.Add(new ValidationResult("Параметр «Диаметр большего цилиндра» должен быть строго больше параметра «Диаметр меньшего цилиндра»!"));
            }

            if (LessCylinderDiameter <= NominalShaftDiameter)
            {
                errors.Add(new ValidationResult("Параметр «Диаметр меньшего цилиндра» должен быть строго больше параметра «d»!"));
            }

            return errors;
        }
    }
}
