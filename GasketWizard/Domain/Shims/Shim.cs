using GasketWizard.Attributes;
using GasketWizard.Enums;
using System.ComponentModel;

namespace GasketWizard.Domain.Shims
{
    [ModelTypeAttributes(ModelType.Part)]
    [PartGroup("Shims", "ru-RU:Шайбы")]
    [PartTitle("Shim", "ru-RU:Шайба")]
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
