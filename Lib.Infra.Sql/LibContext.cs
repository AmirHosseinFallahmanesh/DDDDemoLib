using Lib.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lib.Infra.Sql
{
    public class LibContext:DbContext
    {


        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public LibContext(DbContextOptions<LibContext> options):base(options)
        {


        }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var mut = modelBuilder.Model.GetEntityTypes().SelectMany
                (e => e.GetProperties().Where(p => p.ClrType == typeof(string)));

            foreach (var item in mut)
            {
                item.Relational().ColumnType="nvarchar(100)";
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("DefaultConnection");
        //    }
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var addedEntity = ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("Created") != null).ToList();


            foreach (var item in addedEntity)
            {
                if (item.State==EntityState.Added)
                {
                    item.Property("Created").CurrentValue = DateTime.Now;
                }
                if (item.State==EntityState.Modified)
                {
                    item.Property("Created").IsModified = false;
                    item.Property("Updated").CurrentValue = DateTime.Now;
                }
            }

        
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
