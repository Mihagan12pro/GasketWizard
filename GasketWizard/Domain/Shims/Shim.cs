using GasketWizard.Attributes;
using GasketWizard.Domain.AvaliableDocuments;
using GasketWizard.Enums;
using System.ComponentModel;

namespace GasketWizard.Domain.Shims
{
    [DisplayName("Шайба")]
    [ModelTypeAttributes(ModelType.Part)]
    [PartGroup("Shims")]
    public class Shim : PartBase, IAvaliablePartDocument
    {
        /// <summary>
        /// d
        /// </summary>
        [DisplayName("d")]
        public double InternalDiameter { get; set; }

        /// <summary>
        /// D
        /// </summary>
        [DisplayName("D")]
        public double ExternalDiameter { get; set; }

        /// <summary>
        /// S
        /// </summary>
        [DisplayName("s")]
        public double Width { get; set; }
    }
}
