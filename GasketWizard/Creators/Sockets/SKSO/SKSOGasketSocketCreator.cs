using GasketWizard.Domain.Sockets;

namespace GasketWizard.Creators.Sockets.SKSO
{
    public class SKSOGasketSocketCreator : GasketSocketCreator<SKSOGasketSocket>
    {
        public SKSOGasketSocketCreator(SKSOGasketSocket partModel)
            : base(partModel)
        {
        }
    }
}
