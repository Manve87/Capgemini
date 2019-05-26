using Capgemini.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capgemini.Dtos
{
    public class TaskDto
    {
        public int id { get; set; }
        [StringLength(255)]
        public string taskName { get; set; }
        public UserDto user { get; set; }
    }
}