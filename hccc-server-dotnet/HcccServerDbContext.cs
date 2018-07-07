using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hccc_api
{
    public class HcccServerDbContext : DbContext
    {
        public HcccServerDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Recipe>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Description);
                entity.Property(e => e.Category);
                entity.Property(e => e.SubCategory);
                entity.Property(e => e.Servings);
                entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
                entity.Property(e => e.RevisionDate).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<Models.Ingredient>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.HasOne<Models.Recipe>("Recipe").WithMany("Ingredients");
                entity.Property(e => e.Text);
                entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
                entity.Property(e => e.RevisionDate).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<Models.Direction>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.HasOne<Models.Recipe>("Recipe").WithMany("Directions");
                entity.Property(e => e.Text);
                entity.Property(e => e.Step);
                entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
                entity.Property(e => e.RevisionDate).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<Models.ShoppingListItem>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.Text);
                entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
                entity.Property(e => e.RevisionDate).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<Models.WeeklyMenuItem>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.Date);
                entity.HasOne<Models.Recipe>("Recipe").WithMany();
                entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
                entity.Property(e => e.RevisionDate).ValueGeneratedOnUpdate();
            });
        }
    }
}
