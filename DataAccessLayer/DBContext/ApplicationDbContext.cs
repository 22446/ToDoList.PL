using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataAccessLayer.DBContext
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tasks>().HasKey(a => a.id);
            modelBuilder.Entity<Tasks>().HasOne(a=>a.Object).WithMany(a=>a.tasks).HasForeignKey(a => a.ObjectFK);
                        
         }
        public DbSet<Tasks> tasks { get; set; }
        public DbSet<Models.Objects> objects  { get; set; }
    }
}
