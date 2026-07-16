using GasketWizard.Attributes;
using GasketWizard.Domain.Shims;
using GasketWizard.Domain.ValueObjects;

namespace GasketWizard.Domain.Gaskets
{
    [PartTitle("SKRO gasket", "ru-RU:Сальник односторонний типа СКРО")]
    public class SKROGasket : GasketBase
    {
        [PartParameter("D1")]
        public double SmallCylinderOutsideDiameter { get; set; }

        [PartParameter("d1")]
        public double SmallCylinderInsideDiameter { get; set; }

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
        /// L
        /// </summary>
        [PartParameter("L")]
        public double Length { get; set; }

        [PartParameter("Thread", Enums.SizesTypes.Standart, "ru-RU:Резьба")]
        public MetricThread Thread { get; set; }

        [PartParameter("Shims", Enums.SizesTypes.Standart, "ru-RU:Шайба")]
        public Shim Shim { get; set; }
    }
}
