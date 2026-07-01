using GasketWizard.Attributes;

namespace GasketWizard.Domain.Housing
{
    [PartGroup("Sockets", "ru-RU:Гнезда")]
    [ModelTypeAttributes(Enums.ModelType.Part)]
    public abstract class GasketSocket : PartBase
    {
    }
}
