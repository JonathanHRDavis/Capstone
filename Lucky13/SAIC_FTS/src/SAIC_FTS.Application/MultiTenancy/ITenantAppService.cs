using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SAIC_FTS.MultiTenancy.Dto;

namespace SAIC_FTS.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
