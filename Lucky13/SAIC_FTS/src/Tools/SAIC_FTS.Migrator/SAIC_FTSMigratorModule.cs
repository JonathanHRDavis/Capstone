using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using SAIC_FTS.EntityFramework;

namespace SAIC_FTS.Migrator
{
    [DependsOn(typeof(SAIC_FTSDataModule))]
    public class SAIC_FTSMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<SAIC_FTSDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}