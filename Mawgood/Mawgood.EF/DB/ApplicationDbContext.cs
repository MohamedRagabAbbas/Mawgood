using Mawgood.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Mawgood.EF.DB
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employer>()
                .HasOne(x=>x.User)
                .WithOne(x=>x.Employer)
                .HasForeignKey<Employer>(x => x.UserId);

            builder.Entity<JobSeeker>()
                .HasOne(x => x.User)
                .WithOne(x => x.JobSeeker)
                .HasForeignKey<JobSeeker>(x => x.UserId);



            base.OnModelCreating(builder);
        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }
    }


}
