using IssueTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Api.DataContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options) { }


        public DbSet<Users> Users { get; set; }
        public DbSet<Issues>Issues { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Comments> Comments { get; set; }


       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Issues>()
                .HasOne(i => i.AssignedUser)
                .WithMany()
                .HasForeignKey(i => i.AssignedTo); 

            base.OnModelCreating(modelBuilder);
        }


    }


}
