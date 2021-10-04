using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using PSETIME_BACK.DAL.Models.Entities.GlobalConfigs;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms;
using PSETIME_BACK.DAL.Models.Entities.UserManager;
using System;
using System.IO;

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

        #region Importation
        //public DbSet<UserTime> ImportTimeUsers { get; set; }
        //public DbSet<RevendicationUser> RevendicationUsers { get; internal set; }

        #endregion

        #region Revendications
        public DbSet<RevendicationUser> RevendicationUsers { get; set; }

        public DbSet<RevendicationStatus> RevendicationStatuss { get; set; }
        #endregion

        #region permissions
        public DbSet<PermissionUser> PermissionUsers { get; set; }

        public DbSet<PermissionsStatus> PermissionsStatuss { get; set; }
        #endregion

        #region Configuration
        public DbSet<GlobalConfig> GlobalConfigs { get; set; }
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
                new GlobalConfig { Id = 1, Code = "GC1", Description = "CONFIGURATION GLOABLE 1", Name = "CONFIGURATION GLOABLE 1", StartDate = new DateTime(2021, 01, 01, 9, 0, 0), EndDate = new DateTime(2021, 01, 01, 18, 0, 0), IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" },
                new GlobalConfig { Id = 2, Code = "GC2", Description = "CONFIGURATION GLOABLE 2", Name = "CONFIGURATION GLOABLE 2", StartDate = new DateTime(2021, 01, 01, 8, 0, 0), EndDate = new DateTime(2021, 01, 01, 18, 0, 0), IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" },
                new GlobalConfig { Id = 3, Code = "GC3", Description = "CONFIGURATION GLOABLE 3", Name = "CONFIGURATION GLOABLE 3", StartDate = new DateTime(2021, 01, 01, 7, 30, 0), EndDate = new DateTime(2021, 01, 01, 18, 0, 0), IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" }
                );
        }



    }
}