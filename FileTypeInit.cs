using CsvProcessor.Processors.Interfaces;
using System;
using System.Collections.Generic;

namespace CsvProcessor.Processors
{
    public static class FileTypeInit
    {
        public static Dictionary<Enum, IProcessor> FileTypes = new Dictionary<Enum, IProcessor>();
    }
}
