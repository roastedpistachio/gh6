using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace WebServices.Data
{
    public static class CsvParser
    {
        public static CsvParseResult Parse(string content, bool hasHeaderRow = true)
        {
            return Parse(Encoding.UTF8.GetBytes(content));
        }

        public static CsvParseResult Parse(byte[] content, bool hasHeaderRow = true)
        {
            var firstRow = true;
            var headerRow = Enumerable.Empty<string>();
            var data = new List<IEnumerable<string>>();

            using (var memoryStream = new MemoryStream(content))
            using (var parser = GetParser(memoryStream))
            {
                while (!parser.EndOfData)
                {
                    var row = parser.ReadFields();

                    if (firstRow && hasHeaderRow)
                    {
                        headerRow = row;
                        firstRow = false;
                    }
                    else
                    {
                        data.Add(row);
                    }
                }
            }

            return new CsvParseResult()
            {
                Headers = headerRow,
                Data = data
            };
        }

        private static TextFieldParser GetParser(Stream stream)
        {
            var parser = new TextFieldParser(stream)
            {
                TextFieldType = FieldType.Delimited
            };

            parser.SetDelimiters(",");

            return parser;
        }
    }
}