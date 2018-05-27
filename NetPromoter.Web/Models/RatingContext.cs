using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NetPromoter.Web.Models
{
    public class RatingContext: DbContext
    {
        public RatingContext(): base("netpromoter")
        { }

        public DbSet<AppRating> AppRatings { get; set; }
        public DbSet<PageRating> PageRatings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppRating>().ToTable("AppRating");
            modelBuilder.Entity<PageRating>().ToTable("PageRating");
        }
    }
}