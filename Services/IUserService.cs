using Microsoft.Extensions.Configuration;
using passholder.Context;
using passholder.Models;
using passholder.Repo;
using passholder.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passholder.Services
{
    public interface IUserService
    {
        Task<object> SendOTPToUser(string email);
        Task AddUserLogin(UserLogin usrLogin);
        Task UpdateUserLogin(UserLogin userLogin);
        Task<UserLogin> LogInUser(Guid userId, string otp);
        User GetUser(string email);
        IEnumerable<User> GetAllUser();
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IUserLoginRepository _userLoginRepo;
        private readonly IConfiguration _config;

        public UserService(IUserRepository userRepo, IUserLoginRepository userLoginRepo, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _userLoginRepo = userLoginRepo;
            _config = configuration;
        }
        public async Task AddUserLogin(UserLogin userLogin)
        {
            await _userLoginRepo.Insert(userLogin);
        }
        public async Task UpdateUserLogin(UserLogin userLogin)
        {
            await _userLoginRepo.Update(userLogin);
        }

        public IEnumerable<User> GetAllUser()
        {
            return _userRepo.GetAll().Where(a => a.IsActive);
        }

        public User GetUser(string email)
        {
            return _userRepo.Find(a => a.Email == email).SingleOrDefault();
        }

        public async Task<UserLogin> LogInUser(Guid userId, string otp)
        {
            await Task.Delay(0).ConfigureAwait(false);
            return _userLoginRepo.Find(a => (a.OTP == otp && a.UserId == userId)).SingleOrDefault();
        }

        public async Task<object> SendOTPToUser(string userId)
        {
            string Otp = OTPGenerator.Generate4DigitOTP(4);
            bool isSendEmail = false;
            if (await CheckandSaveUserOTP(Otp, userId))
            {
                EmailUtility emailUtility = new EmailUtility(_config.GetSection("Creds:email:id").Value, _config.GetSection("Creds:email:password").Value);
                isSendEmail = await emailUtility.SendEmail(userId, "Your Passcode", string.Format(EmailTemplate.Password, Otp));
            }
            return new
            {
                emailSend = isSendEmail,
                userId
            };
        }

        private Guid GetUserIdFromEmail(string email)
        {
            return GetUser(email).Id;
        }

        private async Task<bool> CheckandSaveUserOTP(string otp, string userId)
        {
            Guid usrId = Guid.Parse(userId);
            var userLogin = new UserLogin
            {
                OTP = otp,
                OTPCreatedDate = DateTime.Now,
                UserId = usrId,
                LoginDate = DateTime.Now
            };

            UserLogin lgn = CheckForUserEntryInUserLogin(usrId);
            if (lgn != null)
            {
                userLogin.Id = lgn.Id;
                await UpdateUserLogin(userLogin);
                return false;
            }
            else
            {
                await AddUserLogin(userLogin);
                return true;
            }
        }

        private UserLogin CheckForUserEntryInUserLogin(Guid userId)
        {
            return _userLoginRepo.Find(a => a.UserId == userId).FirstOrDefault();
        }
    }
}
