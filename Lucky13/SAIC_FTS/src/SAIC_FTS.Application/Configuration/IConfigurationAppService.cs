using System.Threading.Tasks;
using Abp.Application.Services;
using SAIC_FTS.Configuration.Dto;

namespace SAIC_FTS.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}