using System;

namespace GasketWizard.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    /// <summary>
    /// Specifies the parts's position in the queues.
    /// </summary>
    public class PartPositionInQueueAttribute : Attribute
    {
        public readonly int Position;

        public PartPositionInQueueAttribute(int position)
        {
            Position = position;
        }
    }
}
