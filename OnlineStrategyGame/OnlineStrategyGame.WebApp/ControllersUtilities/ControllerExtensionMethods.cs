using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStrategyGame.WebApp.ControllersUtilities
{
    public static class ControllerExtensionMethods
    {
        /// <summary>
        /// Get culture cookie and set language of static localisation class
        /// </summary>
        /// <param name="controller"></param>
        public static void SetLanguageUsingCookie(this Controller controller)
        {
            if (controller.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName] != null)
            {
                var x = CookieRequestCultureProvider.ParseCookieValue(controller.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName]);
                if (x.Cultures.Count() > 0)
                {
                    var y = x.Cultures[0];
                    Localisation.Localisation.Culture = new System.Globalization.CultureInfo(y.ToString());
                }
            }
        }
    }
}
