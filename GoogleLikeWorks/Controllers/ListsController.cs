using GoogleLikeWorks.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using GoogleLikeWorks.Models;

namespace GoogleLikeWorks.Controllers
{
    public class ListsController : BaseController
    {
        // GET: api/Lists
        public IEnumerable<ListsModel> Get()
        {
            var lists = ListRepository.GetAll();

            return lists;
        }

        // GET: api/Lists/5
        public Tuple<ListsModel, List<PagesModel>, List<TasksModel>> Get(int id)
        {
            var results = ListRepository.Get(id);

            return results;
        }

        // POST: api/Lists
        public int Post([FromBody]ListsModel list)
        {
            var id = ListRepository.NewList(list.Title);

            return id;
        }

        // PUT: api/Lists/5
        public int Put(int id, [FromBody]ListsModel list)
        {
            var result = ListRepository.Get(id);

            if (result.Item1 != null)
            {
                var resultId = ListRepository.NewList(list.Title);

                return resultId;
            }
            else
            {
                ListRepository.UpdateList(id, list.Title);
            }

            return 0;
        }

        // DELETE: api/Lists/5
        public void Delete(int id)
        {
            ListRepository.DeleteList(id);
        }
    }
}
