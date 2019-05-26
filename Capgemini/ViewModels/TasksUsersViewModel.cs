using Capgemini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capgemini.ViewModel
{
    public class TasksUsersViewModel
    {
        public List<User> users { get; set; }
        public List<Task> tasks { get; set; }
}
}