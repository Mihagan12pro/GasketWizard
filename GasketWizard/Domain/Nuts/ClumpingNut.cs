using GasketWizard.Attributes;
using GasketWizard.Domain;
using GasketWizard.Domain.ValueObjects;

namespace GasketWizard.Creators.Nuts
{
    [PartGroup("Nuts", "ru-RU:Гайки")]
    [ModelTypeAttributes(Enums.ModelType.Part)]
    public abstract class ClumpingNut : PartBase
    {
        [PartParameter("Thread", Enums.SizesTypes.Standart, "ru-RU:Резьба")]
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


        [PartParameter("Left cylinder diameter", Enums.SizesTypes.Custom, "ru-RU:Диаметр левого цилиндра")]
        public double LeftCylinderDiameter { get; set; }

        [PartParameter("Right cylinder diameter", Enums.SizesTypes.Custom, "ru-RU:Диаметр правого цилиндра")]
        public double RightCylinderDiameter { get; set; }

        [PartParameter("Thread length", Enums.SizesTypes.Custom, "ru-RU:Длина резьбы")]
        public double ThreadLength { get; set; }

        [PartParameter("Hexagon height", Enums.SizesTypes.Custom, "ru-RU:Высота шестиугольника")]
        public double HexagonHeight { get; set; }

        [PartParameter("Chamfer length", Enums.SizesTypes.Custom, "ru-RU:Длина фаски")]
        public double ChamferLength { get; set; } = 1;
    }
}
