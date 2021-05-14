using passholder.Context;
using passholder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passholder.Repo
{

    public interface ICredentialRepository : ISqlRepository<UserCred>
    {

    }
    public class CredentialRepository : SqlRepository<UserCred>, ICredentialRepository
    {
        public CredentialRepository(PassDbContext passDbContext) : base(passDbContext)
        {
                
        }
    }
}
