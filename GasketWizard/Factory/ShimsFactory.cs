using GasketWizard.Creators.Shims.Part;
using KompasAPI7;

namespace GasketWizard.Factory
{
    public class ShimsFactory
    {
        public ShimPartCreator CreateShimPart(IPartDocument document)
            => new ShimPartCreator(document);
    }
}
