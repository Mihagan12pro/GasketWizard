using GasketWizard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GasketWizard.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ModelTypeAttributes : Attribute
    {
        private List<ModelType> _modelTypes = new List<ModelType>();

        public IReadOnlyList<ModelType> ModelTypes
            => _modelTypes.AsReadOnly();

        public ModelTypeAttributes(params ModelType[] modelTypes)
        {
            _modelTypes = modelTypes.ToList();
        }
    }
}
