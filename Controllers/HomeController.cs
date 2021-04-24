using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using passholder.Context;
using passholder.Extension;
using passholder.Models;
using passholder.Services;
using passholder.Utilities;

namespace passholder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userSvc;

        public HomeController(ILogger<HomeController> logger,IUserService userService)
        {
            _logger = logger;
            _userSvc = userService;
        }

        public IActionResult Index()
        {
            IList<User> users = _userSvc.GetAllUser().ToList();
            return View(users);
        }

        [ActionName("send-otp")]
        [HttpPost]
        public async Task<IActionResult> SendOTPToUser(string usrId)
        {
            _logger.Log(LogLevel.Debug, "SEND-OTP Start", usrId);

            if (string.IsNullOrEmpty(usrId))
                throw new ArgumentNullException($"{nameof(usrId)} is not provided.");
            

            return Json(await _userSvc.SendOTPToUser(usrId));
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(string userId,string otp)
        {
            _logger.Log(LogLevel.Debug, "user-login Start", otp);

            if (string.IsNullOrEmpty(otp))
                throw new ArgumentNullException($"{nameof(otp)} is not provided.");

            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException($"{nameof(userId)} is not provided.");

            if (await _userSvc.LogInUser(Guid.Parse(userId), otp) is null)
                return NotFound();
            else
                return RedirectToAction("Index", "Dashboard");
        }



    }
}
