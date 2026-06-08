using System;

namespace GasketWizard.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PartGroupAttribute : Attribute
    {
        public string Group {  get; set; }

        public PartGroupAttribute(string group)
        {
            Group = group;
        }
    }
}
