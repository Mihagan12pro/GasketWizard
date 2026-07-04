using GasketWizard.Attributes;
using GasketWizard.Domain.Housing;
using GasketWizard.Domain.ValueObjects;
using System.ComponentModel;

namespace GasketWizard.Domain.Sockets
{
    [DisplayName("Гнездо сальника типа СКСД")]
    public class SKSDGasketSocket : GasketSocket
    {
        [Size()]
        [DisplayName("Резьба")]
        public MetricThread Thread { get; set; }


        [Size()]
        [DisplayName("D")]
        public double Diameter { get; set; }

        [Size]
        [DisplayName("L")]
        public double Length { get; set; }
    }
}
