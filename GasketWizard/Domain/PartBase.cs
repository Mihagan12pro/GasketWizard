using System.ComponentModel;

namespace GasketWizard.Domain
{
    public abstract class PartBase
    {
        [DisplayName("№")]
        public int Id { get; set; }
    }
}
