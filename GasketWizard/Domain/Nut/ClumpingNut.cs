using GasketWizard.Attributes;
using GasketWizard.Domain;
using GasketWizard.Domain.ValueObjects;
using System.ComponentModel;

namespace GasketWizard.Creators.Nuts
{
    [PartGroup("Nuts")]
    public abstract class ClumpingNut : PartBase
    {
        /// <summary>
        /// Обозначение резьбы
        /// </summary>
        [DisplayName("Резьба")]
        public MetricThread Thread { get; set; }

        /// <summary>
        /// d
        /// </summary>
        [DisplayName("d")]
        public double NominalShaftDiameter { get; set; }

        /// <summary>
        /// D
        /// </summary>
        [DisplayName("D")]
        public double WidthAcrossCorners { get; set; }

        /// <summary>
        /// s
        /// </summary>
        [DisplayName("s")]
        public double WidthAcrosFlats { get; set; }

        /// <summary>
        /// l
        /// </summary>
        [DisplayName("l")]
        public double Length { get; set; }  
    }
}
