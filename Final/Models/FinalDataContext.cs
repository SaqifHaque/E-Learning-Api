using Final.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class FinalDataContext : DbContext
    {
        public FinalDataContext()
        {
            //Database.SetInitializer<FinalDataContext>(new DropCreateDatabaseIfModelChanges<FinalDataContext>());
            Database.SetInitializer<FinalDataContext>(new MigrateDatabaseToLatestVersion<FinalDataContext, Configuration>());
        }
        virtual public DbSet<User> Users { get; set; }
        virtual public DbSet<Course> Courses { get; set; }
        virtual public DbSet<Category> Categories { get; set; }
        virtual public DbSet<Post> Posts { get; set; }
        virtual public DbSet<Comment> Comments { get; set; }
    }

}