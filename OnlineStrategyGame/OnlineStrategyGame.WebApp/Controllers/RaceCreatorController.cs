using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStrategyGame.WebApp.Models;

namespace OnlineStrategyGame.WebApp.Controllers
{
    public class RaceCreatorController : Controller
    {
        // GET: RaceCreator
        public async Task<IActionResult> Index()
        {
            var result = new RaceCreatorViewModel();
            return View(result);
        }

        // POST: RaceCreator/Select/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Select(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}