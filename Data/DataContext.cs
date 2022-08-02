//#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using Microsoft.EntityFrameworkCore;
using IrishJobs.Data.Mappings;

namespace IrishJobs.Models
{
    public class DataContext : DbContext
    {
        public DbSet<AdModel> AdModels { get; set; }
       
       public DbSet<CompanyModel> CompanyModels { get; set; }

       public DbSet<CandidateModel> CandidateModels { get; set; }

       public DbSet<AdCandidateModel> AdCandidatesModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdModelMap());
            modelBuilder.ApplyConfiguration(new CompanyModelMap());
            modelBuilder.ApplyConfiguration(new CandidateModelMap());
            //modelBuilder.ApplyConfiguration(new AdCandidateModel());
            //modelBuilder.Entity<AdCandidateModel>().HasKey(ac => new { ac.AdId, ac.AdModel });
            
            
        }
    }
}