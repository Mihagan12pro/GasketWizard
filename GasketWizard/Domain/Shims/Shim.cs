using GasketWizard.Attributes;
using GasketWizard.Domain.ValueObjects;
using GasketWizard.Enums;

namespace GasketWizard.Domain.Shims
{
    [ModelTypeAttributes(ModelType.Part)]
    [PartGroup("Shims", "ru-RU:Шайбы")]
    [PartTitle("Shim", "ru-RU:Шайба")]
    public class Shim : PartBase, IValueObject
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

        public string Display
            => $"{InternalDiameter}X{ExternalDiameter}";

        public Shim()
        {
            
        }

        public Shim(string diameters)
        {
            string[] splitedDiameters = diameters.Split('X');

            InternalDiameter = double.Parse(splitedDiameters[0]);
            
            ExternalDiameter = double.Parse(splitedDiameters[1]);
        }
    }
}
