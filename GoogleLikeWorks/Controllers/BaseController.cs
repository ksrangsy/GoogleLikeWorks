using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoogleLikeWorks.Controllers
{
    public class BaseController : ApiController
    {
        public bool ValidateToken(Guid token)
        {
            return true;
        }
    }
}
