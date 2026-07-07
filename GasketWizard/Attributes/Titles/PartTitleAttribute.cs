using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasketWizard.Attributes
{
    public class PartTitleAttribute : LocalizableAttribute
    {
        public string LocalizedTitle => throw new NotImplementedException();

        public string Title { get; }


        public PartTitleAttribute(string title)
        {
            
        }
    }
}
