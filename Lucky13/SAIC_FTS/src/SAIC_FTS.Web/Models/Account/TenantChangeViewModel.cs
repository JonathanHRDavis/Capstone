using Abp.AutoMapper;
using SAIC_FTS.Sessions.Dto;

namespace SAIC_FTS.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}