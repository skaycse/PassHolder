using passholder.Context;
using passholder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passholder.Repo
{
    public interface IUserRepository : ISqlRepository<User>
    {

    }
    public class UserRepository : SqlRepository<User>,IUserRepository
    {
        public UserRepository(PassDbContext passDbContext) : base(passDbContext)
        {

        }
    }

    public interface IUserLoginRepository : ISqlRepository<UserLogin>
    {

    }

    public class UserLoginRepository : SqlRepository<UserLogin>, IUserLoginRepository
    {
        private readonly PassDbContext _passDbContext;
        public UserLoginRepository(PassDbContext passDbContext) : base(passDbContext)
        {
            _passDbContext = passDbContext;
        }

        public async override Task Update(UserLogin userLogin)
        {
            var usrLogin = await base.GetSingle(userLogin.Id);
            usrLogin.OTP = userLogin.OTP;
            usrLogin.OTPCreatedDate = userLogin.OTPCreatedDate;
            _passDbContext.Update(usrLogin);
            await _passDbContext.SaveChangesAsync();
        }

    }
}
