using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SAIC_FTS.Roles.Dto;
using SAIC_FTS.Users.Dto;

namespace SAIC_FTS.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}