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
        protected string path;

        public virtual string GetFilePath()
            => path;

        public virtual void Save(string path)
        {
            this.path = path;
        }


        public virtual bool Create()
        {
            return true;
        }
    }
}
