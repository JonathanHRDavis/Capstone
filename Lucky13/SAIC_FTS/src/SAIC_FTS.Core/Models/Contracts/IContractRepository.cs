using System.Collections.Generic;
using Abp.Domain.Repositories;

namespace SAIC_FTS.Models.Contracts
{
    public interface IContractRepository : IRepository<Contract>
    {
        //List<Contract> GetAllWithContractNumber(int? contractNumber);
        List<Contract> GetAllWithContractNumber(string contractNumber);
        //List<Contract> GetemAll();
    }
}
