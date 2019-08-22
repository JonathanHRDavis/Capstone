using System.Collections.Generic;
using Abp.Domain.Repositories;

namespace SAIC_FTS.Models.Contracts
{
    public interface IContractTextRepository : IRepository<ContractText>
    {
        //List<Contract> GetAllWithContractNumber(int? contractNumber);
        List<ContractText> GetAllWithContractNumber(string contractNumber);
        //List<Contract> GetemAll();
    }
}
