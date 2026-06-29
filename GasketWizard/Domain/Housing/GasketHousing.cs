using GasketWizard.Attributes;

namespace GasketWizard.Domain.Housing
{
    [PartGroup("Nuts", "ru-RU:Корпуса")]
    [ModelTypeAttributes(Enums.ModelType.Part)]
    public abstract class GasketHousing : PartBase
    {
    }
}
