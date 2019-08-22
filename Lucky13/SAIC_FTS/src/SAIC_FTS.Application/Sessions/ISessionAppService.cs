using System.Threading.Tasks;
using Abp.Application.Services;
using SAIC_FTS.Sessions.Dto;

namespace SAIC_FTS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
