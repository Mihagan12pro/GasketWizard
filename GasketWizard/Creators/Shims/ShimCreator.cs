using GasketWizard.Domain.Shims;
using KompasAPI7;

namespace GasketWizard.Creators.Shims
{
    public abstract class ShimCreator : Creator<Shim>
    {
        protected string path;

        public override string GetFilePath()
            => path;

        public override void Save(string path)
        {
            this.path = path;
        }


        public override bool Create()
        {
            return true;
        }

        public ShimCreator(Shim partModel, IKompasDocument document) : base(partModel)
        {
        }
    }
}
