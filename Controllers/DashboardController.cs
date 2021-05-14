using Microsoft.AspNetCore.Authorization;
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
        private readonly ICredentialService _credentialService;
        public DashboardController(IWebsitesService websitesService, ICredentialService credentialService)
        {
            _websiteService = websitesService;
            _credentialService = credentialService;
        }
        public IActionResult Index()
        {
            List<UserCred> model = _credentialService.GetCredentials();
            return View(model);
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

            userCred.UserId = Guid.Parse("98161558-2A4E-4062-AD74-D0CFAA0FD565");
            await _credentialService.SavePassword(userCred);
            return RedirectToAction("Index");
        }
    }
}
;
