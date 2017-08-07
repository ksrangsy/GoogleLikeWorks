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
    public class TasksController : ApiController
    {
        public IEnumerable<TasksModel> GetByList(int listID)
        {
            var tasks = TasksRepository.GetByList(listID);

            return tasks;
        }

        public IEnumerable<TasksModel> GetByPage(int pageID)
        {
            var tasks = TasksRepository.GetByPage(pageID);

            return tasks;
        }

        public TasksModel Get(int taskID)
        {
            var page = TasksRepository.Get(taskID);

            return page;
        }

        public int Post([FromBody]TasksModel task)
        {
            var id = TasksRepository.NewTask(task.PageID, task.Blob);

            return id;
        }

        public int Put(int id, [FromBody]TasksModel task)
        {
            var result = TasksRepository.Get(id);

            if (result != null)
            {
                var resultId = TasksRepository.NewTask(task.PageID, task.Blob);

                return resultId;
            }
            else
            {
                TasksRepository.UpdateTask(task.ID, task.Blob);
            }

            return 0;
        }

        public void Delete(int id)
        {
            TasksRepository.DeleteTask(id);
        }
    }
}
