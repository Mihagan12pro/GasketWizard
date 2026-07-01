using GasketWizard.Domain.Sockets;

namespace GasketWizard.Creators.Sockets
{
    public abstract class SKSDGasketSocketCreator
        : GasketSocketCreator<SKSDGasketSocket>
    {
        public SKSDGasketSocketCreator(SKSDGasketSocket partModel) : base(partModel)
        {
        }
    }
}
