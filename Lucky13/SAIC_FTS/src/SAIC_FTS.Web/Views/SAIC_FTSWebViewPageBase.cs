using Abp.Web.Mvc.Views;

namespace SAIC_FTS.Web.Views
{
    public abstract class SAIC_FTSWebViewPageBase : SAIC_FTSWebViewPageBase<dynamic>
    {

    }

    public abstract class SAIC_FTSWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected SAIC_FTSWebViewPageBase()
        {
            LocalizationSourceName = SAIC_FTSConsts.LocalizationSourceName;
        }
    }
}