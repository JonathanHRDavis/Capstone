using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SolrNet.Attributes;



namespace SAIC_FTS.Models.Contracts
{
    public class SolrContract
    {
        [SolrUniqueKey("ContractNumber")]
        public string ContractNumber { get; set; }

        [SolrField("Contract")]
        public string ContractText { get; set; }
    }
}
