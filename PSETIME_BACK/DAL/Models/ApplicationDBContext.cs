using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using PSETIME_BACK.DAL.Models.Entities.GlobalConfigs;
using PSETIME_BACK.DAL.Models.Entities.UserManager;
using PSETIME_BACK.DAL.Models.Entities.UserTimeImport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DAL.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        #region Administration
        public DbSet<UserGroups> UserGroups { get; set; }
        #endregion


        #region Configuration
        public DbSet<GlobalConfig> GlobalConfigs { get; set; }
        #endregion


        #region Importation
        public DbSet<ImportTimeUser> ImportTimeUsers { get; set; }

        #endregion


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning))
                          .ConfigureWarnings(w => w.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning))
                          .UseNpgsql(connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GlobalConfig>().HasData(
                new GlobalConfig { Id = 1, Code = "GC1", Description = "CONFIGURATION GLOABLE 1", Name = "CONFIGURATION GLOABLE 1", StartDate = new DateTime(2021, 01, 01, 9, 0, 0), EndDate = new DateTime( 2021, 01, 01, 18, 0, 0), IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" },
                new GlobalConfig { Id = 2, Code = "GC2", Description = "CONFIGURATION GLOABLE 2", Name = "CONFIGURATION GLOABLE 2", StartDate = new DateTime(2021, 01, 01, 8, 0, 0), EndDate = new DateTime(2021, 01, 01, 18, 0, 0), IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" },
                new GlobalConfig { Id = 3, Code = "GC3", Description = "CONFIGURATION GLOABLE 3", Name = "CONFIGURATION GLOABLE 3", StartDate = new DateTime(2021, 01, 01, 7, 30, 0), EndDate = new DateTime(2021, 01, 01, 18, 0, 0), IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" }
                ); 

            modelBuilder.Entity<ImportTimeUser>().HasData(
                new ImportTimeUser { Id = 1, Code = "SEM1", Description = "LES JOURS DE LA SEMAINE", Name = "PREMIER JOUR DE LA SEMAINE", WorkDay = new DateTime(2021, 01, 01, 9, 0, 0), TimeWorkBack = new DateTime(2021, 01, 01, 9, 0, 0), TimeWorkCome = new DateTime(2021, 01, 01, 18, 0, 0), IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" },
                new ImportTimeUser { Id = 2, Code = "SEM2", Description = "LES JOURS DE LA SEMAINE", Name = "DEUXIEME JOUR DE LA SEMAINE", WorkDay = new DateTime(2021, 01, 01, 8, 0, 0), TimeWorkCome = new DateTime(2021, 01, 01, 18, 0, 0), TimeWorkBack = new DateTime(2021, 01, 01, 9, 0, 0), IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" },
                new ImportTimeUser { Id = 3, Code = "SEM3", Description = "LES JOURS DE LA SEMAINE", Name = "TROISIEME JOUR DE LA SEMAINE", WorkDay = new DateTime(2021, 01, 01, 7, 30, 0), TimeWorkCome = new DateTime(2021, 01, 01, 18, 0, 0), TimeWorkBack = new DateTime(2021, 01, 01, 9, 0, 0), IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" }
                );
        }



    }
}