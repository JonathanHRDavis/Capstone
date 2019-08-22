using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SAIC_FTS.Roles.Dto;

namespace SAIC_FTS.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
