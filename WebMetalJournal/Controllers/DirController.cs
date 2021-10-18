using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMetalJournal.Others;

namespace WebMetalJournal.Controllers
{
    #region BASECONTROLLER
    public class DirController : Controller
    {
        private LocalDBContext db;
        private readonly ILogger<DirController> _logger;

        public DirController(ILogger<DirController> logger, LocalDBContext context)
        {
            db = context;
            _logger = logger;
        }
        #endregion
        public async Task<IActionResult> OpenDiam()
        {
            return View(await db.diametersDir.ToListAsync());
        }
        public async Task<IActionResult> OpenNom()
        {
            return View(await db.NomenclaturesDir.ToListAsync());
        }
    }
}
