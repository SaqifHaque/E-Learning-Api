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
        virtual public DbSet<Cart> Carts { get; set; }

        virtual public DbSet<Enroll> Enrolls { get; set; }
        virtual public DbSet<Financial> Financials { get; set; }
        virtual public DbSet<Invoice> Invoices { get; set; }
        virtual public DbSet<Video> Videos { get; set; }
        virtual public DbSet<Content> Contents { get; set; }
        virtual public DbSet<Notification> Notifcations { get; set; }
        virtual public DbSet<Status> Statuses { get; set; }
        virtual public DbSet<Notice> Notices { get; set; }
        public List<HyperLink> HyperLinks = new List<HyperLink>();

    }

}