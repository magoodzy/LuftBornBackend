using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MarbellaMS.Authentication;
using MarbellaMS.Entities;
using MarbellaMS.Models;
using MarbellaMS.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MarbellaMS
{
    public class ApplicationDbContext : IdentityDbContext<Users>
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration Configuration) : base(options)
        {
            _configuration = Configuration;
            _connectionString = _configuration.GetConnectionString("ConnStr");
        }
        public DbSet<Users> Users { set; get; }
        public DbSet<Departments> Departments { set; get; }
        public DbSet<Positions> Positions { set; get; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .Property(b => b.Id)
                .IsRequired();
        }

    public IDbConnection CreateConnection()
  => new SqlConnection(_connectionString);
    //public override Task<int> SaveChanges(CancellationToken cancellationToken = new CancellationToken())
    //{
    //    var _dateTime = DateTime.Now;
    //    foreach (var entry in ChangeTracker.Entries<BaseEntity>())
    //    {
    //        switch (entry.State)
    //        {
    //            case EntityState.Added:
    //               // entry.Entity.CreatedAt = _dateTime.NowUtc;
    //               // entry.Entity.CreatedBy = _authenticatedUser.UserId;
    //                break;
    //            case EntityState.Modified:
    //              //  entry.Entity.LastModifiedAt = _dateTime.NowUtc;
    //              //  entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
    //                break;
    //        }
    //    }
    //    return base.SaveChangesAsync(cancellationToken);
    //}
}
}
