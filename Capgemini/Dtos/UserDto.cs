using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Capgemini.Dtos
{
    public class UserDto
    {
        public int id { get; set; }
        [StringLength(255)]
        public string userName { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
}