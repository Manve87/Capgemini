using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capgemini.Models
{
    public class User
    {
        private MyDbContext db = new MyDbContext();

       
        public List<Task> GetTasks()
        {
            var tasks = db.tasks.Where(t => t.user.id == id).ToList();
            if (tasks == null)
            {
                return new List<Task>();
            }
            else
            {
                return tasks;
            }

        }

        public int id { get; set; }
        [StringLength(255)]
        public string userName  { get; set; }
       

    }
}