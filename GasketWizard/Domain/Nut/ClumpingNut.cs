using GasketWizard.Attributes;
using GasketWizard.Domain;
using GasketWizard.Domain.ValueObjects;
using System.ComponentModel;

namespace GasketWizard.Creators.Nuts
{
    [PartGroup("Nuts", "ru-RU:Гайки")]
    [ModelTypeAttributes(Enums.ModelType.Part)]
    public abstract class ClumpingNut : PartBase
    {
        /// <summary>
        /// Обозначение резьбы
        /// </summary>
        [DisplayName("Резьба")]
        [SizeTypes()]
        public MetricThread Thread { get; set; }

        /// <summary>
        /// d
        /// </summary>
        [DisplayName("d")]
        [SizeTypes()]
        public double NominalShaftDiameter { get; set; }

        /// <summary>
        /// D
        /// </summary>
        [DisplayName("D")]
        [SizeTypes()]
        public double WidthAcrossCorners { get; set; }

        /// <summary>
        /// s
        /// </summary>
        [DisplayName("s")]
        [SizeTypes()]
        public double WidthAcrosFlats { get; set; }

        /// <summary>
        /// l
        /// </summary>
        [DisplayName("l")]
        [SizeTypes()]
        public double Length { get; set; }
    }
}
