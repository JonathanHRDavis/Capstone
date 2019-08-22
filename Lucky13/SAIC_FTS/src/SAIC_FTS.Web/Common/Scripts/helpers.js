var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('SAIC_FTS');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);