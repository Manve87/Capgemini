using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capgemini.Models
{
    public class Task
    {
        public int id { get; set; }
        [StringLength(255)]
        public string taskName { get; set; }
        public User user { get; set; }

    }
}