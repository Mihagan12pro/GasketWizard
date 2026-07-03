using GasketWizard.Domain.Sockets;

namespace GasketWizard.Creators.Sockets
{
    public abstract class SKROGasketSocketCreator : Creator<SKROGasketSocket>
    {
        public SKROGasketSocketCreator(SKROGasketSocket partModel) : base(partModel)
        {
        }
    }
}
