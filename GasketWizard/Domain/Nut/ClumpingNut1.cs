using GasketWizard.Attributes;
using System.ComponentModel;

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


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
