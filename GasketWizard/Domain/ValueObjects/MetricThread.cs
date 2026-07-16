using System.Globalization;

namespace GasketWizard.Domain.ValueObjects
{
    public class MetricThread : IValueObject
    {
        public double NominalDiameter { get; set; }

        public double Pitch { get; set; }

        public string Display
        {
            get
            {
                return $"М{NominalDiameter}X{Pitch}";
            }
        }

        public MetricThread(string display)
        {
            string[] values = display.Replace("М", "").Replace("M", "").Split('X');

            double.TryParse(values[0], NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out double nominalDiameter);
            double.TryParse(values[1], NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out double pitch);

            NominalDiameter = nominalDiameter;
            Pitch = pitch;
        }
    }
}
