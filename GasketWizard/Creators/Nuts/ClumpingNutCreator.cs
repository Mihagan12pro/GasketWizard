using KompasAPI7;

namespace GasketWizard.Creators.Nuts
{
    public abstract class ClumpingNutCreator<TNut> : Creator<TNut>
        where TNut : ClumpingNut
    {
        protected ClumpingNutCreator(TNut partModel) : base(partModel)
        {
        }
    }
}
