﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineStrategyGame.WebApp.Controllers.Base;
using OnlineStrategyGame.WebApp.ControllersUtilities;
using OnlineStrategyGame.WebApp.Models;

namespace OnlineStrategyGame.WebApp.Controllers
{
    public class HomeController : BaseController
    {
        private static bool TestLang = true;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            this.SetLanguageUsingCookie();
            return View();
        }

        public IActionResult Privacy()
        {
            this.SetLanguageUsingCookie();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            this.SetLanguageUsingCookie();
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        public IActionResult SetLanguage(string lang)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lang)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return RedirectToAction("Index");
        }
        public ActionResult RedirectToDefaultLanguage()
        {
            return RedirectToAction("Index", new { lang = CurrentLanguage });
        }
    }
}
