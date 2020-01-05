using AppNet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.EFramework
{
    public class AppDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext() : base("Data Source=.\\;Initial Catalog=App;User Id = sa; Password = Bimser123")
        {

        }


    }
}
