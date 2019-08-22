using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using SAIC_FTS.EntityFramework;

namespace SAIC_FTS
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(SAIC_FTSCoreModule))]
    public class SAIC_FTSDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SAIC_FTSDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
