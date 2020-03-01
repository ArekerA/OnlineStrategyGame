using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineStrategyGame.Base.Galaxy;
using OnlineStrategyGame.Base.Galaxy.Interfaces;
using OnlineStrategyGame.Database.MSSQL;
using OnlineStrategyGame.Database.MSSQL.Models;
using OnlineStrategyGame.Dtos.Galaxy;
using OnlineStrategyGame.WebApp.Controllers.Base;

namespace OnlineStrategyGame.WebApp.Controllers
{
    [Authorize(Policy = "ActivePlayerOnly")]
    public class SolarSystemsController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ISolarSystemManager _solarSystemManager;

        public SolarSystemsController(ApplicationDbContext context, ISolarSystemManager solarSystemManager)
        {
            _context = context;
            _solarSystemManager = solarSystemManager;
        }

        // GET: SolarSystems
        public async Task<IActionResult> Index()
        {
            return View(_solarSystemManager.GetSolarSystem(1, 1, 1));
        }

        [HttpPost]
        public async Task<IActionResult> GetSolarSystem(int x, int y, int z)
        {
            var model =  _solarSystemManager.GetSolarSystem(x, y, z);
            return View("Index",model);
        }
    }
}
