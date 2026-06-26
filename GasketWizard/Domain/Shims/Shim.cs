using GasketWizard.Attributes;
using GasketWizard.Enums;
using System.ComponentModel;

namespace GasketWizard.Domain.Shims
{
    [DisplayName("Шайба")]
    [ModelTypeAttributes(ModelType.Part)]
    [PartGroup("Shims", "ru-RU:Гайка")]
    public class Shim : PartBase
    {
        /// <summary>
        /// d
        /// </summary>
        [DisplayName("d")]
        [SizeType()]
        public double InternalDiameter { get; set; }

        /// <summary>
        /// D
        /// </summary>
        [DisplayName("D")]
        [SizeType()]
        public double ExternalDiameter { get; set; }

        /// <summary>
        /// S
        /// </summary>
        [DisplayName("s")]
        [SizeType()]
        public double Width { get; set; }
    }
}
