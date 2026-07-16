using GasketWizard.Attributes;

namespace GasketWizard.Domain.Gaskets
{
    [PartGroup("Gaskets", "ru-RU:Сальники")]
    public abstract class GasketBase
    {
        [PartParameter("Type", Enums.SizesTypes.Standart, "ru-RU:Типоразмер")]
        public string Id { get; set; }
    }
}
