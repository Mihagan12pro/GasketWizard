using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasketWizard.Creators.Nuts
{
    public abstract class ClumpingNutCreator<TNut> : Creator<TNut>
        where TNut : ClumpingNut
    {
        public ClumpingNutCreator(TNut partModel) : base(partModel)
        {
        }
    }
}
