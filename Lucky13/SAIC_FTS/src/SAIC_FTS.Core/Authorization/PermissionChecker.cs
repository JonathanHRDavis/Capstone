using Abp.Authorization;
using SAIC_FTS.Authorization.Roles;
using SAIC_FTS.Authorization.Users;

namespace SAIC_FTS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
