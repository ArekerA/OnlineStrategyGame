using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStrategyGame.Base.RaceCreator.Interfaces;
using OnlineStrategyGame.Dtos.RaceCreator;
using OnlineStrategyGame.WebApp.Models;

namespace OnlineStrategyGame.WebApp.Controllers
{
    public class RaceCreatorController : Controller
    {
        private readonly IRaceCreatorManager _raceCreatorManager;

        public RaceCreatorController(IRaceCreatorManager raceCreatorManager)
        {
            _raceCreatorManager = raceCreatorManager;
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

        public async Task<IActionResult> End()
        {
            return View();
        }
    }
}