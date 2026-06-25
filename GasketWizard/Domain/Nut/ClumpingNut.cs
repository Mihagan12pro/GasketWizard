using GasketWizard.Attributes;
using GasketWizard.Domain;
using GasketWizard.Domain.ValueObjects;
using System.ComponentModel;

namespace GasketWizard.Creators.Nuts
{
    [PartGroup("Nuts")]
    [ModelTypeAttributes(Enums.ModelType.Part)]
    public abstract class ClumpingNut : PartBase
    {
        /// <summary>
        /// Обозначение резьбы
        /// </summary>
        [DisplayName("Резьба")]
        [SizeType()]
        public MetricThread Thread { get; set; }

        /// <summary>
        /// d
        /// </summary>
        [DisplayName("d")]
        [SizeType()]
        public double NominalShaftDiameter { get; set; }

        /// <summary>
        /// D
        /// </summary>
        [DisplayName("D")]
        [SizeType()]
        public double WidthAcrossCorners { get; set; }

        /// <summary>
        /// s
        /// </summary>
        [DisplayName("s")]
        [SizeType()]
        public double WidthAcrosFlats { get; set; }

        /// <summary>
        /// l
        /// </summary>
        [DisplayName("l")]
        [SizeType()]
        public double Length { get; set; }
    }
}
