using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passholder.Models
{
    public class UserCred : BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string WebSiteName { get; set; }
    }
}
