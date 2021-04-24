using Microsoft.AspNetCore.Mvc;
using passholder.Models;
using passholder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passholder.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IWebsitesService _websiteService;
        public DashboardController(IWebsitesService websitesService)
        {
            _websiteService = websitesService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetWebsites()
        {
            return Json(_websiteService.GetWebsiteJson());
        }

        [HttpPost]
        public async Task<IActionResult> SaveCredentials(UserCred userCred)
        { 
            if (userCred is null)
            {
                throw new ArgumentNullException(nameof(userCred));
            }

            await Task.Delay(0);
            return Json("");
        }
    }
}
;
