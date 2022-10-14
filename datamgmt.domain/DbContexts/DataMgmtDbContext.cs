using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using datamgmt.domain.DataModels.Admin;


namespace datamgmt.domain.DbContexts
{
    public class DataMgmtDbContext : DbContext
    {
        private readonly ILogger _logger;
        public DbSet<UserAccount>? UserAccounts { get; set; }
        //public DbSet<AnimalContentDetail>? AnimalContentDetail { get; set; }/* = null!;*/
        //public DbSet<AnimalPart>? AnimalPart { get; set; }/* = null!;*/
        //public DbSet<AnimalSpecies>? AnimalSpecies { get; set; }/* = null!;*/
        public DbSet<Components>? Components { get; set; }/* = null!;*/
        //public DbSet<Manufacturer>? Manufacturer { get; set; }/* = null!;*/
        //public DbSet<PartType>? PartType { get; set; }/* = null!;*/
        //public DbSet<PartClassification>? PartClassification { get; set; }/* = null!;*/
        //public DbSet<PlantSite>? PlantSite { get; set; }/* = null!;*/
        public DbSet<Supplier>? Supplier { get; set; }/* = null!;*/
        public DbSet<USBException>? USBException { get; set; }
        public DbSet<LocalFolderRemediation>? LocalFolderRemediation { get; set; }

        public DataMgmtDbContext(ILogger<DataMgmtDbContext> logger, DbContextOptions<DataMgmtDbContext> options)
           : base(options)
        {
            _logger = logger;

            _logger.LogInformation("Aries Db Context cons at {DT}", DateTime.UtcNow.ToLongTimeString());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().ToTable("UserAccount");

            //modelBuilder.Entity<AnimalContentDetail>().ToTable("AnimalContentDetail", "Aries");

            //modelBuilder.Entity<Supplier>().ToTable("Supplier", "Aries");

            //modelBuilder.Entity<PlantSite>().ToTable("PlantSite", "Aries");

            //modelBuilder.Entity<PartClassification>().ToTable("PartClassification", "Aries");

            //modelBuilder.Entity<PartType>().ToTable("PartType", "Aries");

            //modelBuilder.Entity<Manufacturer>().ToTable("Manufacturer", "Aries");

            modelBuilder.Entity<Components>().ToTable("Component", "Aries");

            //modelBuilder.Entity<AnimalSpecies>().ToTable("AnimalSpecies", "Aries");

            //modelBuilder.Entity<AnimalPart>().ToTable("AnimalPart", "Aries");


            modelBuilder.Entity<USBException>().ToTable("USBException", "DLPP");

            modelBuilder.Entity<LocalFolderRemediation>().ToTable("LocalFolderRemediation", "DLPP");
        }

}

/// <summary>
/// Context factory as a workaround for scaffolding issues 
/// </summary>
public class DataMgmtDbContextFactory : IDesignTimeDbContextFactory<DataMgmtDbContext>
    {
        public DataMgmtDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataMgmtDbContext>();
            optionsBuilder.UseSqlServer("Server=CWQ004679D;TrustServerCertificate=True;Database=Aries;Uid=AriesProd1WebUser;Pwd=nRT#2w3!hC4@Aum;MultipleActiveResultSets=true");

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            return new DataMgmtDbContext(null,optionsBuilder.Options);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }
    }
}
