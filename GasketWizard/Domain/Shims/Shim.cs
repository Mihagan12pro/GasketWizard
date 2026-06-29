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
        [SizeTypes()]
        public double InternalDiameter { get; set; }

        /// <summary>
        /// D
        /// </summary>
        [DisplayName("D")]
        [SizeTypes()]
        public double ExternalDiameter { get; set; }

        /// <summary>
        /// S
        /// </summary>
        [DisplayName("s")]
        [SizeTypes()]
        public double Width { get; set; }
    }
}
