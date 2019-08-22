using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using SAIC_FTS.Authorization.Users;
using SAIC_FTS.Editions;

namespace SAIC_FTS.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore
            ) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore
            )
        {
        }
    }
}