using GasketWizard.Domain;
using System.Collections.Generic;

namespace GasketWizard.Databases.StandartSizes
{
    public interface IStandartSizesDb
    {
        IEnumerable<KompasModel> GetAll(string name);

        KompasModel GetById(string id, string name);
    }
}