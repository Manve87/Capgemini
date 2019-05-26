using Capgemini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Capgemini.Controllers.Api
{
    public class TasksController : ApiController
    {
        private MyDbContext _context;

        public TasksController()
        {
            _context = new MyDbContext();
        }
        //GET api/tasks
        
        public IEnumerable<Task> GetTasks()
        {
            return _context.tasks.ToList();
        }
        //GET api/tasks/{id}
        public Task GetTask(int id)
        {
            var task = _context.tasks.SingleOrDefault(t => t.id == id);
            if (task == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return task;
        }
        //POST /api/tasks
        [HttpPost]
        public Task NewTask (Task task)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.tasks.Add(task);
            _context.SaveChanges();
            return task;
        }
        //PUT /api/tasks/{id}
        [HttpPut]
        public void UpdateTask (int id,Task task)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var TaskInDb = _context.tasks.SingleOrDefault(t => t.id == id);

            if (TaskInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            TaskInDb.taskName = task.taskName;
            _context.SaveChanges();
        }
        // DELETE /api/tasks/{id}
        [HttpDelete]
        public void DeleteTask (int id)
        {
            var TaskInDb = _context.tasks.SingleOrDefault(t => t.id == id);

            if (TaskInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.tasks.Remove(TaskInDb);
            _context.SaveChanges();
        }
    }
}
