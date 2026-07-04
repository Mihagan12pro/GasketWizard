using GasketWizard.Attributes;
using GasketWizard.Enums;
using System.ComponentModel;

namespace GasketWizard.Domain.Shims
{
    [DisplayName("Шайба")]
    [ModelTypeAttributes(ModelType.Part)]
    [PartGroup("Shims", "ru-RU:Шайбы")]
    public class Shim : PartBase
    {
        /// <summary>
        /// d
        /// </summary>
        [DisplayName("d")]
        [Size()]
        public double InternalDiameter { get; set; }

        /// <summary>
        /// D
        /// </summary>
        [DisplayName("D")]
        [Size()]
        public double ExternalDiameter { get; set; }

        /// <summary>
        /// S
        /// </summary>
        [DisplayName("s")]
        [Size()]
        public double Width { get; set; }
    }
}
