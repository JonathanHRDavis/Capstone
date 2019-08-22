using System.Collections.Generic;

namespace SAIC_FTS.Models.Contracts.Dtos
{
    public class GetContractsOutput
    {
        public List<ContractDto> Contracts { get; set; }
    }
}
