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
            var lists = ListsRepository.GetAll();

            return lists;
        }

        // GET: api/Lists/5
        public Tuple<ListsModel, List<PagesModel>, List<TasksModel>> Get(int id)
        {
            var results = ListsRepository.Get(id);

            return results;
        }

        // POST: api/Lists
        public int Post([FromBody]ListsModel list)
        {
            var id = ListsRepository.NewList(list.Title);

            return id;
        }

        // PUT: api/Lists/5
        public int Put(int id, [FromBody]ListsModel list)
        {
            var result = ListsRepository.Get(id);

            if (result.Item1 != null)
            {
                var resultId = ListsRepository.NewList(list.Title);

                return resultId;
            }
            else
            {
                ListsRepository.UpdateList(id, list.Title);
            }

            return 0;
        }

        // DELETE: api/Lists/5
        public void Delete(int id)
        {
            ListsRepository.DeleteList(id);
        }
    }
}
