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
        [PartParameter("Thread", Enums.SizeTypes.Standart, "ru-RU:Резьба")]
        public MetricThread Thread { get; set; }

        /// <summary>
        /// d
        /// </summary>
        [PartParameter("d")]
        public double NominalShaftDiameter { get; set; }

        /// <summary>
        /// D
        /// </summary>
        [PartParameter("D")]
        public double WidthAcrossCorners { get; set; }

        /// <summary>
        /// s
        /// </summary>
        [PartParameter("s")]
        public double WidthAcrosFlats { get; set; }

        /// <summary>
        /// l
        /// </summary>
        [PartParameter("l")]
        public double Length { get; set; }
    }
}
