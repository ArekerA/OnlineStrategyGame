using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using System.Collections.Generic;
using System.Globalization;

namespace OnlineStrategyGame.WebApp.Routing
{
    public class LocalizationPipeline
    {
        public void Configure(IApplicationBuilder app)
        {
            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en"),
                new CultureInfo("pl"),
            };

            var options = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            options.RequestCultureProviders = new[] { new RouteDataRequestCultureProvider() { Options = options, RouteDataStringKey = "lang", UIRouteDataStringKey = "lang" } };

            app.UseRequestLocalization(options);
        }
    }
}