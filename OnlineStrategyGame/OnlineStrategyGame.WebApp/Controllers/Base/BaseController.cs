using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace OnlineStrategyGame.WebApp.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        private string _currentLanguage;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1308:Znormalizuj ciągi do wielkich liter", Justification = "<Oczekujące>")]
        protected string CurrentLanguage
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentLanguage))
                {
                    return _currentLanguage;
                }

                if (string.IsNullOrEmpty(_currentLanguage))
                {
                    var feature = HttpContext.Features.Get<IRequestCultureFeature>();
                    _currentLanguage = feature.RequestCulture.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
                }

                return _currentLanguage;
            }
        }
    }
}