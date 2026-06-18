using GasketWizard.Domain.Shims;
using KompasAPI7;

namespace GasketWizard.Creators.Shims
{
    public abstract class ShimCreator : Creator<Shim>
    {
        public ShimCreator(Shim partModel, IKompasDocument document) : base(partModel)
        {
        }
    }
}
