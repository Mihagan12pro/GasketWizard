using GasketWizard.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GasketWizard.Domain.Gaskets
{
    [PartGroup("Gaskets", "ru-RU:Сальники")]
    public abstract class GasketBase : KompasModel<string>
    {
        [PartParameter("Type", Enums.SizesTypes.Standart, "ru-RU:Типоразмер")]
        public string Id { get; set; }

        public override object GetId()
            => Id;

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}
