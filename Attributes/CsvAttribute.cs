using System;

namespace CsvProcessor.Processors.Attributes
{
    [System.AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public  class CsvAttribute : Attribute
    {
        public readonly string Position;

        public CsvAttribute(string index)
        {
            Position = index;
        }
    }
}
