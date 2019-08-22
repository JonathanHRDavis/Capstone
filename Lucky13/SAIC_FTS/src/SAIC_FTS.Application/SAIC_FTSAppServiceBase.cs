using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using SAIC_FTS.Authorization.Users;
using SAIC_FTS.MultiTenancy;
using SAIC_FTS.Users;
using Microsoft.AspNet.Identity;

namespace SAIC_FTS
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class SAIC_FTSAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected SAIC_FTSAppServiceBase()
        {
            LocalizationSourceName = SAIC_FTSConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}