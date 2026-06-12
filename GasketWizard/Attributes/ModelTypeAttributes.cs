using GasketWizard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasketWizard.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ModelTypeAttributes : Attribute
    {
        private List<ModelType> _modelTypes = new List<ModelType>();

        public IReadOnlyList<ModelType> ModelTypes
            => _modelTypes.AsReadOnly();
    }
}
