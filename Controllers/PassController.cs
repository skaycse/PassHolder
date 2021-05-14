using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passholder.Controllers
{
    [Route("")]
    public class PassController : Controller
    {
        [Route("get-values")]
        public string Values()
        {
            return "working on  ity";
        }
    }

    
}
