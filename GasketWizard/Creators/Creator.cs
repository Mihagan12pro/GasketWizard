using GasketWizard.Domain;

namespace GasketWizard.Creators
{
    public abstract class Creator<TPartModel> : Creator
        where TPartModel : PartBase
    {
        protected TPartModel partModel;

        public Creator(TPartModel partModel)
        {
            this.partModel = partModel;
        }
    }

    public abstract class Creator
    {
        public abstract bool Create();

        public abstract void Save(string path);

        public abstract string GetFilePath();
    }
}
