using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TravelBookingProject.Models
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class LoginContext : DbContext
    {
        public LoginContext() : base("name=connstr")
        {

        }

        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<GCM> GCMs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Travelers> Travelers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        

    }
}