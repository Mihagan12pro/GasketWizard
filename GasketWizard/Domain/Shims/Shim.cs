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
        [PartParameter("d")]
        public double InternalDiameter { get; set; }

        /// <summary>
        /// D
        /// </summary>
        [PartParameter("D")]
        public double ExternalDiameter { get; set; }

        /// <summary>
        /// S
        /// </summary>
        [PartParameter("s")]
        public double Width { get; set; }
    }
}
