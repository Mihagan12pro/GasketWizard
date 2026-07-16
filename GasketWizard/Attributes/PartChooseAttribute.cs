using GasketWizard.Domain;
using System;
using System.Collections.Generic;

namespace GasketWizard.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    /// <summary>
    /// Provides choossing parts for assembly
    /// </summary>
    public class PartChooseAttribute : Attribute
    {
        private List<Type> partTypes = new List<Type>();

        public IReadOnlyList<Type> PartTypes
            => partTypes.AsReadOnly();

        public PartChooseAttribute(params Type[] types)
        {
            foreach (var t in types)
            {
                if (t != typeof(PartBase) && t.BaseType != typeof(PartBase))
                    throw new InvalidOperationException(); 

                partTypes.Add(t);
            }
        }
    }
}
