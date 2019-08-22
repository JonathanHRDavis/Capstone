using System.Linq;
using SAIC_FTS.EntityFramework;
using SAIC_FTS.MultiTenancy;

namespace SAIC_FTS.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly SAIC_FTSDbContext _context;

        public DefaultTenantCreator(SAIC_FTSDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
