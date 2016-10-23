using System.Collections.Generic;

namespace WebServices.Data
{
    public class CsvParseResult
    {
        public IEnumerable<string> Headers { get; set; }
        public IEnumerable<IEnumerable<string>> Data { get; set; }
    }
}