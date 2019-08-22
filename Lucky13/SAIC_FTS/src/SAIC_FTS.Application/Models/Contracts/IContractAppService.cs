using Abp.Application.Services;
using SAIC_FTS.Models.Contracts.Dtos;

namespace SAIC_FTS.Models.Contracts
{
    public interface IContractAppService : IApplicationService
    {
        GetContractsOutput GetContracts(GetContractsInput input);

        GetContractsOutput FullTextSearch(string searchstring);

        string getContractText(string contractNumber);

        void CreateContract(CreateContractInput input);

        void TestUpload(string binary, string extn);
        void DeltaImport();
    }
}
