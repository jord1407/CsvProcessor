using System.Data;

namespace CsvProcessor.Processors.Interfaces
{
    public interface IProcessor
    {
        void Process(DataTable datatable);
    }
}
