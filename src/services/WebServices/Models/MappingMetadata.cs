using System.Collections.Generic;

namespace WebServices.Models
{
    public class MappingMetadata
    {
        public string FileName { get; set; }
        public string RiskType { get; set; }
        public IEnumerable<Mapping> Mappings { get; set; }
    }
}