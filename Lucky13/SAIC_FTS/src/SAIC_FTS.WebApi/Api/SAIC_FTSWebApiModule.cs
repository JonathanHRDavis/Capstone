using System.Reflection;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace SAIC_FTS
{
    [DependsOn(typeof(AbpWebApiModule), typeof(SAIC_FTSApplicationModule))]
    public class SAIC_FTSWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(SAIC_FTSApplicationModule).Assembly, "app")
                .Build();

            //Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
              //  .For<Models.Contracts.IContractAppService>("app/test")
                //.Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));
        }
    }
}
