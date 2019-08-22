using Abp.Application.Navigation;
using Abp.Localization;
using SAIC_FTS.Authorization;

namespace SAIC_FTS.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class SAIC_FTSNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Search",
                        new LocalizableString("Search", SAIC_FTSConsts.LocalizationSourceName),
                        url: "#/search",
                        icon: "fa fa-info" //TODO: Custom icon goes here
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Data",
                        new LocalizableString("Data", SAIC_FTSConsts.LocalizationSourceName),
                        url: "#/data",
                        icon: "fa fa-info" //TODO: Custom icon goes here
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Help",
                        new LocalizableString("Help", SAIC_FTSConsts.LocalizationSourceName),
                        url: "#/help",
                        icon: "fa fa-info" //TODO: Cusotm icon goes here
                        )
                );
                /*.AddItem(
                    new MenuItemDefinition(
                        "Test",
                        new LocalizableString("Test", SAIC_FTSConsts.LocalizationSourceName),
                        url: "#/test",
                        icon: "fa fa-info"
                        )
                );

            
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", SAIC_FTSConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home",
                        requiresAuthentication: true
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Tenants",
                        L("Tenants"),
                        url: "#tenants",
                        icon: "fa fa-globe",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Users",
                        L("Users"),
                        url: "#users",
                        icon: "fa fa-users",
                        requiredPermissionName: PermissionNames.Pages_Users
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Roles",
                        L("Roles"),
                        url: "#users",
                        icon: "fa fa-tag",
                        requiredPermissionName: PermissionNames.Pages_Roles
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", SAIC_FTSConsts.LocalizationSourceName),
                        url: "#/about",
                        icon: "fa fa-info"
                        )
                );
                */
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SAIC_FTSConsts.LocalizationSourceName);
        }
    }
}
