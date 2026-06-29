using GasketWizard.Enums;
using System;

namespace GasketWizard.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SizeTypesAttribute : Attribute
    {
        public readonly SizeTypes SizeType;

        public SizeTypesAttribute(SizeTypes sizeType = SizeTypes.Standart)
        {
            SizeType = sizeType;
        }
    }
}
