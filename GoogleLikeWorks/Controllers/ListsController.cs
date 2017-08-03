using GoogleLikeWorks.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoogleLikeWorks.Controllers
{
    public class ListsController : BaseController
    {
        // GET: api/Lists
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Lists/5
        public string Get(Guid token, int id)
        {
            if (!ValidateToken(token))
            {
                Console.WriteLine("ValidateToken failed!");
            }

            var lists = TestTableRepository.GetAll();

            return "value";
        }

        // POST: api/Lists
        public void Post([FromBody]string value)
        {
            Console.WriteLine("HI");
        }

        // PUT: api/Lists/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Lists/5
        public void Delete(int id)
        {
        }
    }
}
