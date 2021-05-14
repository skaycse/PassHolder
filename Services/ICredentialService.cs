using passholder.Models;
using passholder.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passholder.Services
{
    public interface ICredentialService
    {
        Task SavePassword(UserCred User);
        List<UserCred> GetCredentials();
    }

    public class CredentialService : ICredentialService
    {
        public readonly ICredentialRepository _credentialRepo;
        
        public CredentialService(ICredentialRepository credentialRepository)
        {
            _credentialRepo = credentialRepository;
        }

        public List<UserCred> GetCredentials()
        {
            return _credentialRepo.GetAll().ToList();
        }

        public async Task SavePassword(UserCred userCred)
        {
            await _credentialRepo.Insert(userCred);
        }
    }
}
