using GasketWizard.Attributes;
using GasketWizard.Enums;
using GasketWizard.Extensions;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GasketWizard.Creators.Nuts
{
    [DisplayName("Нажимная гайка, исполнение 1")]
    public class ClumpingNut1 : ClumpingNut
    {
        [SizeTypes(Enums.SizeTypes.Custom)]
        [DisplayName("Высота шестиугольника")]
        public double HexagonHeight { get; set; }

        [SizeTypes(Enums.SizeTypes.Custom)]
        [DisplayName("Длина резьбы")]
        public double ThreadLength { get; set; }

        [SizeTypes(Enums.SizeTypes.Custom)]
        [DisplayName("Длина фаски")]
        public double ChamferLength { get; set; }

        [SizeTypes(Enums.SizeTypes.Custom)]
        [DisplayName("Диаметр большего цилиндра")]
        public double BigCylinderDiameter { get; set; }

        [SizeTypes(Enums.SizeTypes.Custom)]
        [DisplayName("Диаметр меньшего цилиндра")]
        public double LessCylinderDiameter { get; set; }


        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            PropertyInfo[] props = this.GetType()
                .GetProperties()
                .Where(p => p.GetCustomAttribute<SizeTypesAttribute>() != null && p.GetCustomAttribute<SizeTypesAttribute>().SizeType == SizeTypes.Custom)
                .ToArray();


            foreach(PropertyInfo prop in props)
            {
                double value = (double)prop.GetValue(this);

                if (value <= 0)
                    errors.Add(new ValidationResult($"Параметр «{prop.GetDisplayName()}» должен быть больше нуля!"));
            }

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

            return errors;
        }
    }
}
