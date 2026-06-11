using GasketWizard.Domain;
using System.Collections.Generic;

namespace GasketWizard.Databases.StandartSizes
{
    public interface IStandartSizesDb
    {
        IEnumerable<PartBase> GetAll(string name);
    }
}