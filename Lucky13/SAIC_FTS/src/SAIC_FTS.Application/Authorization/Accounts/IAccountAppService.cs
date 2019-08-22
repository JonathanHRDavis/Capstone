using System.Threading.Tasks;
using Abp.Application.Services;
using SAIC_FTS.Authorization.Accounts.Dto;

namespace SAIC_FTS.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
