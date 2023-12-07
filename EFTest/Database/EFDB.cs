using EFTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFTest.Database
{
    public class EFDB : DbContext
    {
        public EFDB() : base("AnimeDB")
        {
            System.Data.Entity.Database.SetInitializer<EFDB>(new CreateDatabaseIfNotExists<EFDB>());
        }

        public DbSet<AniList> AnimeProp { get; set; }
        public DbSet<Rating> AnimeRating { get; set; }


        //Fluent API (Property Mapping)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Adding property to models Via Property Mapping
            modelBuilder.Entity<AniList>()
                .Property(p => p.Name)
                .HasColumnName("nawa")
                .HasColumnOrder(3)
                .HasColumnType("varchar")
                .IsRequired();

            modelBuilder.Entity<Rating>()
                .Property(x => x.RatiingNumber)
                .IsOptional();

            modelBuilder.Entity<AniList>() //It will create SP for Insert,Update,Delete
                .MapToStoredProcedures();

            modelBuilder.Entity<AniList>() // Maping to Custome SP 
                .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("InsertAnime").Parameter(pm => pm.Name,"Name").Result(rs => rs.Id,"id"))
                .Delete(sp => sp.HasName("DeleteAnime").Parameter(pm => pm.Id,"id"))
                );
        }
    }
}