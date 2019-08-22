using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using SAIC_FTS.Configuration.Dto;

namespace SAIC_FTS.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SAIC_FTSAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
