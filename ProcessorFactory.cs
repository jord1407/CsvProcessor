using CsvProcessor.Processors.Interfaces;
using System;

namespace CsvProcessor.Processors
{
    public class ProcessorFactory<T> where T : Enum
    {
        public readonly IProcessor Processor;

        public ProcessorFactory(T fileType)
        {
            if (FileTypeInit.FileTypes.ContainsKey(fileType))
                Processor = FileTypeInit.FileTypes[fileType];
        }
    }
}
