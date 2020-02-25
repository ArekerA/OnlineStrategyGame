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
    public class PlanetController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IPlanetManager _planetManager;

        public PlanetController(ApplicationDbContext context, IPlanetManager planetManager)
        {
            _context = context;
            _planetManager = planetManager;
        }

        public async Task<IActionResult> Index(int id)
        {
            return View(_planetManager.GetPlanet(id));
        }

    }
}
