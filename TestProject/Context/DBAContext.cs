using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestProject.Models;

namespace TestProject
{
    public class DBAContext: DbContext
    {
        public DBAContext()
            : base("DbConnection")
        { }

        public DbSet<User> Users { get; set; }

        
    }

}