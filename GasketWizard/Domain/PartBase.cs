using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GasketWizard.Domain
{
    public abstract class PartBase
    {
        [DisplayName("№")]
        public int Id { get; set; }
    }
}
