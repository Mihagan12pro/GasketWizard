using System.ComponentModel;

namespace GasketWizard.Domain.Shims
{
    [DisplayName("Шайба")]
    public class Shim : PartBase
    {
        /// <summary>
        /// d
        /// </summary>
        public double InternalDiameter { get; set; }

        /// <summary>
        /// D
        /// </summary>
        public double ExternalDiameter { get; set; }
        
        /// <summary>
        /// S
        /// </summary>
        public double Width { get; set; }
    }
}
