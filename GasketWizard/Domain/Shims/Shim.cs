using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace GasketWizard.Domain.Shims
{
    [DisplayName("Шайба")]
    public class Shim : PartBase
    {
        /// <summary>
        /// d
        /// </summary>
        [DisplayName("d")]
        public double InternalDiameter { get; set; }

        /// <summary>
        /// D
        /// </summary>
        [DisplayName("D")]
        public double ExternalDiameter { get; set; }

        /// <summary>
        /// S
        /// </summary>
        [DisplayName("s")]
        public double Width { get; set; }
    }
}
