using GasketWizard.Domain;

namespace GasketWizard.Creators
{
    public interface ICreator<TPartModel> 
        where TPartModel : PartBase
    {
        bool Create(TPartModel partModel);

        void Save(string path);

        string GetGilePath();
    }
}
