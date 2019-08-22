using SAIC_FTS.EntityFramework;
using EntityFramework.DynamicFilters;

namespace SAIC_FTS.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly SAIC_FTSDbContext _context;

        public InitialHostDbBuilder(SAIC_FTSDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
