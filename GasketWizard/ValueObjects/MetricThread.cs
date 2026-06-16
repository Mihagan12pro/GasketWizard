using System.Globalization;

namespace GasketWizard.ValueObjects
{
    public class MetricThread
    {
        public double Pitch { get; set; }   

        public double NominalDiameter { get; set; }

        public MetricThread()
        {
            
        }

        public MetricThread(string thread)
        {
            string[] parameters = thread.Split('X');

            double.TryParse(parameters[1], NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out double nominalDiameter);
            double.TryParse(parameters[0], NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out double pitch);

            NominalDiameter = nominalDiameter;
            Pitch = pitch;
        }
    }
}
