using GasketWizard.Attributes;
using GasketWizard.Domain;
using GasketWizard.Domain.ValueObjects;

namespace GasketWizard.Creators.Nuts
{
    [PartGroup("Nuts", "ru-RU:Гайки")]
    [ModelTypeAttributes(Enums.ModelType.Part)]
    public abstract class ClumpingNut : PartBase
    {
        /// <summary>
        /// Обозначение резьбы
        /// </summary>
        [Size("Thread", Enums.SizeTypes.Standart, "ru-RU:Резьба")]
        public MetricThread Thread { get; set; }

        /// <summary>
        /// d
        /// </summary>
        [Size("d")]
        public double NominalShaftDiameter { get; set; }

        /// <summary>
        /// D
        /// </summary>
        [Size("D")]
        public double WidthAcrossCorners { get; set; }

        /// <summary>
        /// s
        /// </summary>
        [Size("s")]
        public double WidthAcrosFlats { get; set; }

        /// <summary>
        /// l
        /// </summary>
        [Size("l")]
        public double Length { get; set; }
    }
}
