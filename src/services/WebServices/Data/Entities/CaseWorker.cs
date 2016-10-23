using System.Collections;
using System.Collections.Generic;

namespace WebServices.Data.Entities
{
    public class CaseWorker
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<IncomingRiskFactor> IncomingRiskFactors { get; set; }
    }
}