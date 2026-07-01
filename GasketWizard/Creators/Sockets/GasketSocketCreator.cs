using GasketWizard.Domain.Housing;

namespace GasketWizard.Creators.Sockets
{
    public abstract class GasketSocketCreator<TSocket>
        : Creator<TSocket> where TSocket : GasketSocket
    {
        public GasketSocketCreator(TSocket partModel) : base(partModel)
        {
        }
    }
}
