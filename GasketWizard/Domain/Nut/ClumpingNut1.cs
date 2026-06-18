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
    }
}
