using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Capgemini.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Task> tasks { get; set; }
        public DbSet<User> users { get; set; }
    }
}