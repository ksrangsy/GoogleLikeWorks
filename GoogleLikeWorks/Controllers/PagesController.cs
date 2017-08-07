using GoogleLikeWorks.Models;
using GoogleLikeWorks.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoogleLikeWorks.Controllers
{
    public class PagesController : BaseController
    {
        public IEnumerable<PagesModel> GetByList(int listID)
        {
            var pages = PagesRepository.GetByList(listID);

            return pages;
        }

        public PagesModel Get(int pageID)
        {
            var page = PagesRepository.Get(pageID);

            return page;
        }

        public int Post([FromBody]PagesModel page)
        {
            var id = PagesRepository.NewPage(page.ListID, page.Title);

            return id;
        }

        public int Put(int id, [FromBody]PagesModel page)
        {
            var result = PagesRepository.Get(id);

            if (result != null)
            {
                var resultId = PagesRepository.NewPage(page.ListID, page.Title);

                return resultId;
            }
            else
            {
                PagesRepository.UpdatePage(id, page.Title);
            }

            return 0;
        }

        public void Delete(int id)
        {
            PagesRepository.DeletePage(id);
        }
    }
}
