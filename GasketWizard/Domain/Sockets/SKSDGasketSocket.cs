using GasketWizard.Attributes;
using GasketWizard.Domain.Housing;
using GasketWizard.Domain.ValueObjects;

namespace GasketWizard.Domain.Sockets
{
    [PartTitle("SKSD-type gasket socket", "ru-RU:Гнездо сальника типа СКСД")]
    public class SKSDGasketSocket : GasketSocket
    {
        [PartParameter("Thread", Enums.SizeTypes.Standart, "ru-RU:Резьба")]
        public MetricThread Thread { get; set; }


        [PartParameter("D")]
        public double Diameter { get; set; }

        [PartParameter("L")]
        public double Length { get; set; }
    }
}
