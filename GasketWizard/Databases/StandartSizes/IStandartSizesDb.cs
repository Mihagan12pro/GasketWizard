using GasketWizard.Domain;
using System.Collections.Generic;

namespace GasketWizard.Databases.StandartSizes
{
    public interface IStandartSizesDb
    {
        Dictionary<string, List<string>> GetAll(string name);
    }
}