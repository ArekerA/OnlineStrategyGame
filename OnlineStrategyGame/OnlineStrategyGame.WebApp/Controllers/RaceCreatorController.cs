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

        public async Task<IActionResult> Select(int id)
        {
            var elements = _raceCreatorManager.GetElements(id);
            if (elements == null)
                return View(nameof(End));
            var result = new RaceCreatorViewModel();
            result.Elements.AddRange(elements);
            return View(nameof(Index), result);
        }

        public async Task<IActionResult> End()
        {
            return View();
        }
    }
}