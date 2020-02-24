using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineStrategyGame.Base.RaceCreator.Interfaces;
using OnlineStrategyGame.Base.Security;
using OnlineStrategyGame.Database.MSSQL.Models;
using OnlineStrategyGame.Dtos.RaceCreator;
using OnlineStrategyGame.WebApp.Controllers.Base;
using OnlineStrategyGame.WebApp.Models;
using OnlineStrategyGame.WebApp.Routing;

namespace OnlineStrategyGame.WebApp.Controllers
{
    [Authorize(Policy = "NewPlayerOnly")]
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class RaceCreatorController : BaseController
    {
        private readonly IRaceCreatorManager _raceCreatorManager;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;

        public RaceCreatorController(UserManager<AppIdentityUser> userManager,
            IRaceCreatorManager raceCreatorManager,
            SignInManager<AppIdentityUser> signInManager)
        {
            _userManager = userManager;
            _raceCreatorManager = raceCreatorManager;
            _signInManager = signInManager;

        }
        // GET: RaceCreator
        public async Task<IActionResult> Index()
        {
            var elements = _raceCreatorManager.GetElements();
            var result = new RaceCreatorViewModel();
            result.Elements.AddRange(elements);
            //
            return View(result);
        }
        public async Task<IActionResult> Select()
        {
            return await Index();
        }

        [HttpPost]
        public async Task<IActionResult> Select(int id, int[] selected)
        {
            var elements = _raceCreatorManager.GetElements(id);
            var result = new RaceCreatorViewModel();
            result.SelectedIds.Add(id);
            result.SelectedIds.AddRange(selected);
            foreach (var item in result.SelectedIds)
            {
                result.Selected.Add(_raceCreatorManager.GetElement(item));

            }
            result.Selected.Sort(delegate (RaceCreatorElementDto x, RaceCreatorElementDto y)
            {
                return x.Id.CompareTo(y.Id);
            });
            result.Bonuses = _raceCreatorManager.GetSummaryBonuses(result.Selected);
            if (elements == null)
                return View(nameof(End), result);
            result.Elements.AddRange(elements);
            return View(nameof(Index), result);
        }

        public async Task<IActionResult> End(int[] selected)
        {
            return View(selected);
        }
        public async Task<IActionResult> Save(int[] ids)
        {
            var user = await _userManager.GetUserAsync(User);
            await _userManager.RemoveClaimAsync(user, ClaimStaticManager.GetNewPlayerClaim());
            await _userManager.AddClaimAsync(user, ClaimStaticManager.GetActivePlayerClaim());
            await _signInManager.RefreshSignInAsync(user);
            _raceCreatorManager.Save(ids, user.Id);
            return RedirectToAction("Index","Home");
        }
    }
}