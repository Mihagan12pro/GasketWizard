using GasketWizard.Enums;
using System;

namespace GasketWizard.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SizeTypeAttribute : Attribute
    {
        public readonly SizeType SizeType;

        public SizeTypeAttribute(SizeType sizeType = SizeType.Standart)
        {
            SizeType = sizeType;
        }
    }
}
