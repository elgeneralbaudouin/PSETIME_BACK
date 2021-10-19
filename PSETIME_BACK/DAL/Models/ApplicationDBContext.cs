using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public class ApplicationDBContext : IdentityDbContext<Users>
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        #region Administration
        public DbSet<UserGroups> UserGroups { get; set; }
        public DbSet<Claims> Claimss { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GlobalConfig>().HasData(
                new GlobalConfig { Id = 1, Code = "GC1", Description = "CONFIGURATION GLOABLE 1", Name = "CONFIGURATION GLOABLE 1", StartDate = new DateTime(2021, 01, 01, 9, 0, 0), EndDate = new DateTime(2021, 01, 01, 18, 0, 0), IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" },
                new GlobalConfig { Id = 2, Code = "GC2", Description = "CONFIGURATION GLOABLE 2", Name = "CONFIGURATION GLOABLE 2", StartDate = new DateTime(2021, 01, 01, 8, 0, 0), EndDate = new DateTime(2021, 01, 01, 18, 0, 0), IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" },
                new GlobalConfig { Id = 3, Code = "GC3", Description = "CONFIGURATION GLOABLE 3", Name = "CONFIGURATION GLOABLE 3", StartDate = new DateTime(2021, 01, 01, 7, 30, 0), EndDate = new DateTime(2021, 01, 01, 18, 0, 0), IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" }
                );



            builder.Entity<PermissionsStatus>().HasData(
                new PermissionsStatus { Id = 1, Code = "PENDING", Description = "PERMISSION ON PENDING FOR TRAITEMENT", Name = "PENDING", IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" },
                new PermissionsStatus { Id = 2, Code = "ACCEPTED", Description = "PERMISSION ACCEPTED", Name = "ACCEPTED", IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" },
                new PermissionsStatus { Id = 3, Code = "REJECTED", Description = "PERMISSION REJECTED", Name = "REJECTED", IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" }
                );



            builder.Entity<RevendicationStatus>().HasData(
                new RevendicationStatus { Id = 1, Code = "PENDING", Description = "REVENDICATION ON PENDING FOR TRAITEMENT", Name = "PENDING", IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" },
                new RevendicationStatus { Id = 2, Code = "ACCEPTED", Description = "REVENDICATION ACCEPTED", Name = "ACCEPTED", IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" },
                new RevendicationStatus { Id = 3, Code = "REJECTED", Description = "REVENDICATION REJECTED", Name = "REJECTED", IsActive = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "1", UpdatedBy = "1" }
                );

        }



    }
}